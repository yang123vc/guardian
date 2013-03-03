using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guardian
{
    public class SMARTAttributeException : ApplicationException
    {
        public SMARTAttributeException()
            : base()
        { }

        public SMARTAttributeException(string message)
            : base(message)
        { }
    }
}
