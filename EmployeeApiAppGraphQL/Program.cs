using EmployeeApiAppGraphQL.DbContextApp;
using EmployeeApiAppGraphQL.GraphQl;
using EmployeeApiAppGraphQL.GraphQl.Mutation;
using EmployeeApiAppGraphQL.GraphQl.Query;
using EmployeeApiAppGraphQL.Repository;
using GraphQL.Server;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        corsBuilder => corsBuilder.WithOrigins("http://localhost:5173")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod()
                                  .AllowCredentials());
});
//
builder.Services.AddGraphQL(options => {
    options.EnableMetrics = false;
}).AddSystemTextJson();
// 
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultSQLConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    ), ServiceLifetime.Transient);
//
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<EmployeeQuery>();
builder.Services.AddScoped<AppSchema>();
builder.Services.AddScoped<EmployeeMutation>();
builder.Services.AddControllers();
// Add GraphQL
builder.Services.AddGraphQL(options =>
{
    options.EnableMetrics = false;
}).AddSystemTextJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Enable CORS with the specified policy
app.UseCors("AllowSpecificOrigin");
// Register GraphQL endpoints
app.UseGraphQL<AppSchema>();
app.UseGraphQLGraphiQL("/ui/graphql");
app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();
