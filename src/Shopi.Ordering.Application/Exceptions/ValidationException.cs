using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopi.Ordering.Application.Exceptions
{
    public class ValidationException : BaseExcepiton
    {

     
        public ValidationException(List<string> messages) :base(messages)
        {

        }

        public ValidationException(string message) :base(message)
        {
    
        }
    }
}
