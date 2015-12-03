using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class OrderParser : IOrderParser
    {
        public Order ParseOrder(string order)
        {
            var orderItems = order.Split(',');
            var retVal = new List<int>();
            int testFirst;
            // make sure first item is not an int (enum would still parse it)
            if (int.TryParse(orderItems[0], out testFirst))
            {
                throw new ApplicationException("Missing time of day as first item");
            }
            var timeOfDay = (TimeOfDay)Enum.Parse(typeof(TimeOfDay), orderItems[0]);
            for (int i = 1; i < orderItems.Length; i++)
            {
                int parsedOrder = 0;
                if (int.TryParse(orderItems[i], out parsedOrder))
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
                Dishes = retVal,
                TimeOfDay = timeOfDay
            };
        }
    }
}
