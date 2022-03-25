using System.Runtime.Serialization;

namespace studentmanagementsystem
{
    internal class LimitExcedeedException : ApplicationException
    {
        public LimitExcedeedException()
        {
        }

        public LimitExcedeedException(string? message) : base(message)
        {
        }
    }
}