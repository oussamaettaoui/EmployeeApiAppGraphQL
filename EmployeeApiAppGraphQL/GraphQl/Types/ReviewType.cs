﻿using EmployeeApiAppGraphQL.Model;
using GraphQL.Types;

namespace EmployeeApiAppGraphQL.GraphQl.Types
{
    public class ReviewType : ObjectGraphType<Review>
    {
        public ReviewType()
        {
            Field(d => d.Id, type: typeof(IdGraphType)).Description("Id property for Review object");
            Field(d => d.Rate, type: typeof(IdGraphType)).Description("Rate property for Review object");
            Field(d => d.Comment, type: typeof(StringGraphType)).Description("Comment property for Review object");
        }
    }
}
