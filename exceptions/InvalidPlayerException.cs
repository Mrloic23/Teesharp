using System;
using System.Runtime.Serialization;

namespace Teeko.Exceptions
{
    [Serializable]
    internal class InvalidPlayerException : Exception
    {
        public InvalidPlayerException()
        {
            
        }

        public InvalidPlayerException(string message) : base(message)
        {
        }

        public InvalidPlayerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidPlayerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}