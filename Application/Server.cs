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
        
        public string TakeOrder(string unparsedOrder)
        {
            try
            {
                Order order = ParseOrder(unparsedOrder);
                List<Dish> dishes = _dishManager.GetDishes(order);
                string retVal = FormatOutput(dishes);
                return retVal;
            }
            catch (ApplicationException e)
            {
                return "error";
            }
        }

        private Order ParseOrder(string order)
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
            return new Order
            {
                Dishes = retVal
            };
        }

        private string FormatOutput(List<Dish> dishes)
        {
            var retVal = "";

            foreach (var dish in dishes)
            {
                retVal = retVal + string.Format(",{0}{1}", dish.DishName, GetMultiple(dish.Count));
            }
            if (retVal.StartsWith(","))
            {
                retVal = retVal.TrimStart(',');
            }
            return retVal;
        }

        private object GetMultiple(int count)
        {
            if (count > 1)
            {
                return string.Format("(x{0})", count);
            }
            return "";
        }
    }
}
