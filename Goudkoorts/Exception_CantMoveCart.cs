using System;
using System.Runtime.Serialization;

namespace Goudkoorts
{
    [Serializable]
    internal class Exception_CantMoveCart : Exception
    {
        public Exception_CantMoveCart()
        {
        }

        public Exception_CantMoveCart(string message) : base(message)
        {
        }

        public Exception_CantMoveCart(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected Exception_CantMoveCart(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}