using System;

namespace WebApplication1.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string messege) : base(messege)
        { 

        }
    }
}
