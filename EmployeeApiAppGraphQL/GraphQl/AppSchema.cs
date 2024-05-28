using EmployeeApiAppGraphQL.GraphQl.Mutation;
using EmployeeApiAppGraphQL.GraphQl.Query;
using GraphQL.Types;

namespace EmployeeApiAppGraphQL.GraphQl
{
    public class AppSchema : Schema
    {
        public AppSchema(EmployeeQuery query , EmployeeMutation mutation)
        {
            this.Query = query;
            this.Mutation = mutation;
        }
    }
}
