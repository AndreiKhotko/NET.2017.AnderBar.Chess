using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngine.Exceptions
{
    public class BusyCellException : Exception
    {
        public BusyCellException() { }

        public BusyCellException(string message) : base(message) { }

        public BusyCellException(string message, Exception inner) : base(message, inner) { }

        protected BusyCellException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
