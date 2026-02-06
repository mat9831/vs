using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebApplication1.Models;
using WebApplication1.Models.Enums;


namespace WebApplication1.Data
{
    public class SeedingService
    {
        private WebApplication1Context _context;

        public SeedingService(WebApplication1Context context)
        {
            _context = context; 
        }

        public void Seed()
        {
            if (_context.Department.Any()|| 
                _context.Seller.Any()|| 
                _context.SalesRecords.Any())
        {
            return; //banco de dados ja foi populado
        }
            Department d1 = new Department("Computers");
            Department d2 = new Department("Eletronics");
            Department d3 = new Department("Fashion");
            Department d4 = new Department("Books");

            Seller s1 = new Seller("Bob Stevie", "bob@gmail.com", new DateTime(2002, 9, 21), 5000.0, d1);
            Seller s2 = new Seller("Orlando gama", "orlando@gmail.com", new DateTime(2001, 4, 20), 1000.0, d2);
            Seller s3 = new Seller("Pitaço silva", "pitaco@gmail.com", new DateTime(2004, 1, 22), 3000.0, d3);
            Seller s4 = new Seller("Mardes ferreira", "mardes@gmail.com", new DateTime(2000, 3, 29), 7000.0, d4);
            Seller s5 = new Seller("Hamilton sousa", "hami@gmail.com", new DateTime(2003, 8, 26), 9000.0, d1);
            Seller s6 = new Seller("Milly stack", "milly@gmail.com", new DateTime(2005, 7, 23), 8000.0, d2);

            SalesRecords r1 = new SalesRecords(new DateTime(2018, 9, 25), 11000.0, SaleStatus.Billed, s1);
            SalesRecords r2 = new SalesRecords(new DateTime(2018, 9, 4), 7000.0, SaleStatus.Billed, s5);
            SalesRecords r3 = new SalesRecords(new DateTime(2018, 9, 13), 4000.0, SaleStatus.Canceled, s4);
            SalesRecords r4 = new SalesRecords(new DateTime(2018, 9, 1), 8000.0, SaleStatus.Billed, s1);
            SalesRecords r5 = new SalesRecords(new DateTime(2018, 9, 21), 3000.0, SaleStatus.Billed, s3);
            SalesRecords r6 = new SalesRecords(new DateTime(2018, 9, 15), 2000.0, SaleStatus.Billed, s1);
            SalesRecords r7 = new SalesRecords(new DateTime(2018, 9, 28), 13000.0, SaleStatus.Billed, s2);
            SalesRecords r8 = new SalesRecords(new DateTime(2018, 9, 11), 4000.0, SaleStatus.Billed, s4);


            _context.Department.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);

            _context.SalesRecords.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8
            );

            _context.SaveChanges();

        }
    }
}
