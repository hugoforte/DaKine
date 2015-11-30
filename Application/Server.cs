using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Server : IServer
    {
        private readonly IDishManager _dishManager;

        public Server(IDishManager dishManager)
        {
            _dishManager = dishManager;
        }

        public string TakeOrder(string order)
        {

            try
            {
                List<int> intOrders = ParseOrderToInts(order);
                var retVal = _dishManager.GetDishes(intOrders);


            }
            catch (ApplicationException e)
            {
                return "error";
            }

            return "";
        }

        private List<int> ParseOrderToInts(string order)
        {
            var orderItems = order.Split(',');
            var retVal = new List<int>();
            foreach (var orderItem in orderItems)
            {
                int parsedOrder = 0;
                if (int.TryParse(orderItem, out parsedOrder))
                {
                    retVal.Add(parsedOrder);
                }
                else
                {
                    throw new ApplicationException("Order needs to be comma separated list of numbers");
                }
            }
            return retVal;
        }
    }

    public class Dish
    {
        public string DishName { get; set; }
        public int Count { get; set; }
    }
}
