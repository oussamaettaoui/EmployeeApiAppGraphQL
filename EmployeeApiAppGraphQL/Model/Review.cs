using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApiAppGraphQL.Model
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required int Rate { get; set; }

        public required string Comment { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public required Employee Employee { get; set; }
    }
}
