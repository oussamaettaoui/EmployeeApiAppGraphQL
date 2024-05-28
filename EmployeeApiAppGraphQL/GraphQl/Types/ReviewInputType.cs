using GraphQL.Types;

namespace EmployeeApiAppGraphQL.GraphQl.Types
{
    public class ReviewInputType : InputObjectGraphType
    {
        public ReviewInputType()
        {
            Name = "ReviewInputType";
            Field<IntGraphType>("Rate");
            Field<StringGraphType>("Comment");
            
        }
    }
}
