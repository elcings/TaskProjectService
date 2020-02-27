using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TaskProjectService
{
    public class TaskService : ITaskService
    {
        IExceptionHandler _handler;
        public TaskService()
        {
            _handler = new ExceptionHandler();
        }

        
        public int Add(int a, int b)
        {
            using (var client = new RabitaService.CalculatorSoapClient())
            {
                //string myQueue = ".\\private$\\ElchinQ";

                //if (!MessageQueue.Exists(myQueue))
                //{
                //    MessageQueue.Create(myQueue, false);
                //}
                var response = _handler.Run(() => client.Add(a, b));
                return response;
            }
        }

        public int Divide(int a, int b)
        {
            using (var client = new RabitaService.CalculatorSoapClient())
            {
                var response = _handler.Run(() => client.Divide(a, b));
                return response;
            }
        }

        public int Multiply(int a, int b)
        {
            using (var client = new RabitaService.CalculatorSoapClient())
            {
                var response = _handler.Run(() => client.Multiply(a, b));
                return response;
            }
        }

        public int Subtract(int a, int b)
        {
            using (var client = new RabitaService.CalculatorSoapClient())
            {
                var response = _handler.Run(() => client.Subtract(a, b));
                return response;
            }
        }
    }
}
