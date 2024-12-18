using System.ComponentModel.DataAnnotations;

namespace CMSAPIOnetoMany.Models
{
    public class Company
    {
        [Key]
        public int CompId { get; set; }
        public string? CompName { get; set; }

        //Navigation Property
        public ICollection<Employee>? Employees { get; set; }
    }
}
