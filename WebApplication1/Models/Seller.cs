using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace WebApplication1.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} Required")]
        [StringLength(100, MinimumLength = 8, ErrorMessage ="{0} size should be betweer {2} and {1}")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} Required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        [DisplayFormat(DataFormatString ="{0:F2}")]
        [Display(Name = "Base Salary")]
        [Required(ErrorMessage = "{0} Required")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        public double BaseSalary { get; set; }
        public Department? Department { get; set; }
        [Display(Name = "Department ID")]
        public int DepartmentId { get; set; }
        public ICollection<SalesRecords> Sales { get; set; } = new List<SalesRecords>();

        public Seller()
        { 
        }

        public Seller(string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }
    }
}
