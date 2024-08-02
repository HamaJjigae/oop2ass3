using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    public class CannotRemoveException : Exception
    {
        public CannotRemoveException() { }

        public CannotRemoveException(string message) : base(message) { }

        public CannotRemoveException(string message, Exception inner) : base(message, inner) { }
    }
}