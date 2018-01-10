using System;
using System.Collections.Generic;
using System.Text;

namespace Arch.Exceptions
{
    public class InitializationException: Exception
    {
 
        public InitializationException(string message)
            : base(message)
        {

        }

 
        public InitializationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
