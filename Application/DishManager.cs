using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class DishManager : IDishManager
    {
        /// <summary>
        /// Takes an Order object, sorts the orders and builds a list of dishes to be returned. 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public List<Dish> GetDishes(Order order)
        {
            var retVal = new List<Dish>();
            order.Dishes.Sort();
            foreach (var dishType in order.Dishes)
            {
                AddOrderToList(dishType, retVal);
            }
            return retVal;
        }

        /// <summary>
        /// Takes an int, representing an order type, tries to find it in the list.
        /// If the dish type does not exist, add it and set count to 1
        /// If the type exists, check if multiples are allowed and increment that instances count by one
        /// else throw error
        /// </summary>
        /// <param name="order">int, represents a dishtype</param>
        /// <param name="retVal">a list of dishes. </param>
        private void AddOrderToList(int order, List<Dish> retVal)
        {
            string orderName = GetEveningOrderName(order);
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
            else
            {
                throw new ApplicationException(string.Format("Multiple {0}(s) not allowed", orderName));
            }
        }

        private string GetEveningOrderName(int order)
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

        private string GetMorningOrderName(int order)
        {
            switch (order)
            {
                case 1:
                    return "egg";
                case 2:
                    return "toast";
                case 3:
                    return "coffee";
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