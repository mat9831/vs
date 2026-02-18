using Microsoft.Identity.Client;

namespace WebApplication1.Services.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(string messege) : base (messege) 
        { 
         
        }
    }
}
