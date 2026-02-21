using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Services
{
    public class SalesRecordService
    {
        private readonly WebApplication1Context _context;

        public SalesRecordService(WebApplication1Context context)
        {
            _context = context;
        }
        public async Task<List<SalesRecords>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecords select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);

            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);

            }
            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
    }
}
