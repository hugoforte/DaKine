using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class DishManager : IDishManager
    {
        public List<Dish> GetDishes(Order order)
        {
            var retVal = new List<Dish>();
            order.OrderTypes.Sort();
            foreach (var orderType in order.OrderTypes)
            {
                AddOrderToList(orderType, retVal);
            }
            return retVal;
        }

        private void AddOrderToList(int order, List<Dish> retVal)
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
            } else if (IsMultipleAllowed(order))
            {
                existingOrder.Count++;
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


        private bool IsMultipleAllowed(int order)
        {
            switch (order)
            {
                case 2:
                    return true;
                default:
                    return false;

            }
        }
    }
}