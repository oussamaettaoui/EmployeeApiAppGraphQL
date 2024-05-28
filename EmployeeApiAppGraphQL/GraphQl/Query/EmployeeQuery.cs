using EmployeeApiAppGraphQL.GraphQl.Types;
using EmployeeApiAppGraphQL.Model;
using EmployeeApiAppGraphQL.Repository;
using GraphQL;
using GraphQL.Types;

namespace EmployeeApiAppGraphQL.GraphQl.Query
{
    public class EmployeeQuery : ObjectGraphType
    {
        public EmployeeQuery(EmployeeRepository repository)
        {
            Field<ListGraphType<EmployeeType>>(
                    "employees",
                    "Return all the Employees",
                    resolve: context => repository.GetAllEmployees()
                );
            Field<EmployeeType>(
                    "employee",
                    "Return a single employee by id",
                    new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" , Description = "Employee Id"}),
                    resolve : context => repository.GetEmployeeById(context.GetArgument("id",int.MinValue))
                );
        }
    }
}
