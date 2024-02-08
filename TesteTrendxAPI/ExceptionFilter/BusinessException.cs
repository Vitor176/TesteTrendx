using System;

namespace ToDoListAPI.ExceptionFilter
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }
    }
}
