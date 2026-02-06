using WebApplication1.Models.Enums;

namespace WebApplication1.Models
{
    public class SalesRecords
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }

        public Seller Seller { get; set; }
        public int SellerId { get; set; }

        public SalesRecords() { }

        public SalesRecords(DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}