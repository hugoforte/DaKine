using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;

namespace GrosvenorInHousePracticum
{
    class Program
    {
        static void Main(string[] args)
        {

            var server = new Server(new DishManager());
            while (true)
            {

                var order = Console.ReadLine();
                var output = server.TakeOrder(order);
                Console.WriteLine(output);

            }
        }
    }
}
