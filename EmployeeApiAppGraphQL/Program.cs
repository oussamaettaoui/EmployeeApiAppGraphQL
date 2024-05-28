using EmployeeApiAppGraphQL.DbContextApp;
using EmployeeApiAppGraphQL.GraphQl;
using EmployeeApiAppGraphQL.GraphQl.Mutation;
using EmployeeApiAppGraphQL.GraphQl.Query;
using EmployeeApiAppGraphQL.Repository;
using GraphQL.Server;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"), sqlOptions => sqlOptions.EnableRetryOnFailure()), ServiceLifetime.Transient);
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<EmployeeQuery>();
builder.Services.AddScoped<AppSchema>();
builder.Services.AddScoped<EmployeeMutation>();
builder.Services.AddControllers();
// Register GraphQl
builder.Services.AddGraphQL().AddSystemTextJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//GraphQl
app.UseGraphQL<AppSchema>();
app.UseGraphQLGraphiQL("/ui/graphql");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
