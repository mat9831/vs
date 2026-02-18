using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
namespace WebApplication1.Models.ViewModels

{
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; }

        [ValidateNever]
        public ICollection<Department> Departments { get; set; }
    }
}