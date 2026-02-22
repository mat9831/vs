using System.Collections.Generic;
using System;
using System.Linq;
using WebApplication1.Migrations;
namespace WebApplication1.Models

{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department() { }

        public Department(string name)
        {
            Name = name;
        }
        
    
    public double TotalSales(DateTime Initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(Initial, final));
        }

    }
}

