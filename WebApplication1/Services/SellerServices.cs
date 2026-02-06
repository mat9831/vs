using WebApplication1.Data;
using WebApplication1.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WebApplication1.Services
{
    public class SellerServices
    {
        private readonly WebApplication1Context _context;

        public SellerServices(WebApplication1Context context)
        {
            _context = context;
        }
        public List<Seller> FindAll() 
        {
            return _context.Seller.ToList();
        }
    }
}
