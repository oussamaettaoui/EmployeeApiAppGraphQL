using EmployeeApiAppGraphQL.GraphQl.Types;
using EmployeeApiAppGraphQL.Model;
using EmployeeApiAppGraphQL.Repository;
using GraphQL;
using GraphQL.Types;

namespace EmployeeApiAppGraphQL.GraphQl.Mutation
{
    public class EmployeeMutation : ObjectGraphType
    {
        public EmployeeMutation(EmployeeRepository repository)
        {
            Field<EmployeeType>(
                    "addEmployee",
                    "Is used to add a new Employee to the database",
                    arguments : new QueryArguments(new QueryArgument<NonNullGraphType<EmployeeInputType>> { Name="employee" , Description="Employee input parameter"}),
                    resolve : context =>
                    {
                        var employee = context.GetArgument<Employee>("employee");
                        if (employee != null)
                        {
                            return repository.AddEmployee(employee);
                        }
                        return null;
                    });
            Field<EmployeeType>(
               "updateEmployee",
               "Is used to update a existing employee to the database",
               arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "Id of the employee that need to be updated" },
                   new QueryArgument<NonNullGraphType<EmployeeInputType>> { Name = "employee", Description = "Employee input parameter." }
                   ),
               resolve: context =>
               {
                   var id = context.GetArgument<int>("id");
                   var employee = context.GetArgument<Employee>("employee");
                   if (employee != null)
                   {
                       return repository.UpdateEmployee(id, employee);
                   }
                   return null;
               });
            Field<EmployeeType>(
              "deleteEmployee",
              "Is used to delete a existing employee to the database",
              arguments: new QueryArguments(
                  new QueryArgument<NonNullGraphType<IdGraphType>>
                  {
                      Name = "id",
                      Description = "Id of the employee that need to be deleted"
                  }
                  ),
              resolve: context =>
              {
                  var id = context.GetArgument<int>("id");
                  repository.DeleteEmployee(id);
                  return true;
              });
        }
    }
}
