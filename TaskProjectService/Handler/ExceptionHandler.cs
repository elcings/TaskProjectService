using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace TaskProjectService
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly Logger _logger;
        public ExceptionHandler()
        {
            _logger = LogManager.GetLogger("database");
        }
        public T Run<T>(Func<T> func)
        {
            try
            {
                var response= func.Invoke();
               _logger.Info($"Success: {JsonConvert.SerializeObject(response)}");
                return response;
            }
            catch (Exception exc)
            {
                _logger.Error($"Error: {JsonConvert.SerializeObject(exc)}");
                throw new FaultException("Soap servislə məlumat mübadiləsində xəta baş vermişdir");
            }
        }
    }
}