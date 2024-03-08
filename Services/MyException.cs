using System;

namespace Toolkit
{

    /// <summary>
    /// Especialização de exception para uso nos erros
    /// </summary>
    public class MyException : Exception
    {

        /// <summary>
        /// Cointrutor principal
        /// </summary>
        /// <param name="message"></param>
        public MyException(string message)
            : base(message)
        {

        }

        //public MyException(string message, MyException exception)
        //    : base(message, exception)
        //{

        //}
    }
}
