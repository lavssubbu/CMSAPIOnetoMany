using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSAPIOnetoMany.Models
{
    public class Employee
    {
        [Key]
        public int empId { get; set; }
        public string? empName { get; set; }
        public decimal empSal { get; set; }
        public DateTime JoiningDate { get; set; }
        public int companyId {  get; set; }

        //Navigation Property
        [ForeignKey("companyId")]
        public Company? Company { get; set; }

    }
}
