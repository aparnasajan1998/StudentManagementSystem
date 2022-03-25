namespace studentmanagementsystem
{
    using System;

    public class EnrollmentException : ApplicationException
    {
        public EnrollmentException()
        {
        }

        public EnrollmentException(string message)
        {
            Console.WriteLine("\n" + message + "\n");
        }
    }
}

