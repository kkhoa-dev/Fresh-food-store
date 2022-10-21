using System;
using System.Collections.Generic;
using System.Text;

namespace FFS.Utilities.Exceptions
{
    public class FFSException : Exception
    {
        public FFSException()
        {
        }

        public FFSException(string message)
            : base(message)
        {
        }

        public FFSException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
