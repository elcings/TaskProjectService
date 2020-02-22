using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TaskProjectService
{
    public class TaskService : ITaskService
    {
        private readonly Logger _logger;

        public TaskService()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }
        public int Add(int a, int b)
        {
            using (var client = new RabitaService.CalculatorSoapClient())
            {
                try
                {
                    _logger.Info($"Request: Soap = {a} and {b}");
                    var response = client.Add(a, b);
                    _logger.Info($"Success: {JsonConvert.SerializeObject(response)}");
                    return response;

                }
                catch (FaultException exc)
                {
                    _logger.Error($"Error: {JsonConvert.SerializeObject(exc)}");
                    throw exc;
                }
                catch (Exception exc)
                {
                    _logger.Error($"Error: {JsonConvert.SerializeObject(exc)}");
                    throw new FaultException("Soap servislə məlumat mübadiləsində xəta baş vermişdir");
                }
            }
        }

        public int Divide(int a, int b)
        {
            using (var client = new RabitaService.CalculatorSoapClient())
            {
                try
                {
                    _logger.Info($"Request: Soap = {a} and {b}");
                    var response = client.Divide(a, b);
                    _logger.Info($"Success: {JsonConvert.SerializeObject(response)}");
                    return response;
                }
                catch (DivideByZeroException exc)
                {
                    _logger.Error($"Error: {JsonConvert.SerializeObject(exc)}");
                    throw exc;
                }
                catch (Exception exc)
                {
                    _logger.Error($"Error: {JsonConvert.SerializeObject(exc)}");
                    throw new FaultException("Soap servislə məlumat mübadiləsində xəta baş vermişdir");

                }
            }
        }

        public int Multiply(int a, int b)
        {
            using (var client = new RabitaService.CalculatorSoapClient())
            {
                try
                {
                    _logger.Info($"Request: Soap = {a} and {b}");
                    var response = client.Divide(a, b);
                    _logger.Info($"Success: {JsonConvert.SerializeObject(response)}");
                    return response;
                }
                catch (OverflowException exc)
                {
                    _logger.Error($"Error: {JsonConvert.SerializeObject(exc)}");
                    throw exc;
                }
                catch (Exception exc)
                {
                    _logger.Error($"Error: {JsonConvert.SerializeObject(exc)}");
                    throw new FaultException("Soap servislə məlumat mübadiləsində xəta baş vermişdir");

                }
            }
        }

        public int Subtract(int a, int b)
        {
            using (var client = new RabitaService.CalculatorSoapClient())
            {
                try
                {
                    _logger.Info($"Request: Soap = {a} and {b}");
                    var response = client.Divide(a, b);
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
}
