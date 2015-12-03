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
            var dishes = new List<int>();
            var timeOfDay = orderItems[0];
            bool isValidOrder = CheckForValidTimeOfDay(timeOfDay);
            for (int i = 1; i < orderItems.Length; i++)
            {
                int parsedOrder = 0;
                if (int.TryParse(orderItems[i], out parsedOrder))
                {
                    dishes.Add(parsedOrder);
                }
                else
                {
                    isValidOrder = false;
                }
            }
            if(isValidOrder == false)
            {
                throw new ApplicationException("Order needs to be comma separated list of numbers");
            }
            return new Order
            {
                Dishes = dishes
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

        private bool CheckForValidTimeOfDay(string timeOfDay)
        {
            bool isValid = false;
            if (timeOfDay.ToLower() == "morning" || timeOfDay.ToLower() == "evening")
            {
                isValid = true;
            }
            return isValid;
        }
    }
}
