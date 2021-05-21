using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopi.Ordering.Application.Exceptions
{
    public abstract class BaseExcepiton : Exception
    {

        public List<string> Messages { get; set; }
        public BaseExcepiton(List<string> messages)
        {
            Data[GetType().Name] = messages;
        }

        public BaseExcepiton(string message) 
        {
            Messages = new List<string>();
            Messages.Add(message);
            Data[GetType().Name] = Messages;
        }
}
}

