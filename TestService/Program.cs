using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference.TaskServiceClient client = new ServiceReference.TaskServiceClient();
           int a=  client.Add(5, 6);
            Console.WriteLine(a);
            Console.ReadLine();
        }
    }
}
