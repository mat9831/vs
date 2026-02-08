using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace WebApplication1.Models
{
    public class Seller
    {
        
    public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        public double BaseSalary { get; set; }

        // 🔥 CHAVE ESTRANGEIRA É O QUE É REQUIRED
        [Required]
        public int DepartmentId { get; set; }

        // 🔥 PROPRIEDADE DE NAVEGAÇÃO SEM REQUIRED
        public Department? Department { get; set; }


       


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
