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
        private readonly IOrderParser _orderParser;

        public Server(IDishManager dishManager, IOrderParser orderParser)
        {
            _dishManager = dishManager;
            _orderParser = orderParser;
        }
        
        public string TakeOrder(string unparsedOrder)
        {
            try
            {
                Order order = _orderParser.ParseOrder(unparsedOrder);
                List<Dish> dishes = _dishManager.GetDishes(order);
                string retVal = FormatOutput(dishes);
                return retVal;
            }
            catch (Exception e)
            {
                return "error";
            }
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
