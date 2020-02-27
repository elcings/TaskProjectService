using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskProjectService
{
    public interface IExceptionHandler
    {
        T Run<T>(Func<T> func);
    }
}