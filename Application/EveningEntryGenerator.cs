using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Application
{
    public class EveningEntryGenerator : IEntryGenerator
    {
        public void AddOrderToList(int order, List<Dish> retVal)
        {
            string orderName = GetOrderName(order);
            var existingOrder = retVal.SingleOrDefault(x => x.DishName == orderName);
            if (existingOrder == null)
            {
                retVal.Add(new Dish
                {
                    DishName = orderName,
                    Count = 1
                });
            }
            else if (IsMultipleAllowed(order))
            {
                existingOrder.Count++;
            }
            else
            {
                throw new ApplicationException(string.Format("Multiple {0}(s) not allowed", orderName));
            }
        }
        private string GetOrderName(int order)
        {
            switch (order)
            {
                case 1:
                    return "steak";
                case 2:
                    return "potato";
                case 3:
                    return "wine";
                case 4:
                    return "cake";
                default:
                    throw new ApplicationException("Order does not exist");

            }
        }
    }
}
