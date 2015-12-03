using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class DishManager : IDishManager
    {
        private IDishMapper _dishMapper;

        /// <summary>
        /// Takes an Order object, sorts the orders and builds a list of dishes to be returned. 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public List<Dish> GetDishes(Order order)
        {
            var retVal = new List<Dish>();
            order.Dishes.Sort();
            _dishMapper = MockedGetDishMapper(order.TimeOfDay);
            foreach (var dishType in order.Dishes)
            {
                AddDishToList(dishType, retVal);
            }
            return retVal;
        }

        /// <summary>
        /// Takes an int, representing a dish type, tries to find it in the list.
        /// If the dish type does not exist, add it and set count to 1
        /// If the type exists, check if multiples are allowed and increment that instances count by one
        /// else throw error
        /// </summary>
        /// <param name="dish">int, represents a dishtype</param>
        /// <param name="retVal">a list of dishes. </param>
        private void AddDishToList(int dish, List<Dish> retVal)
        {
            string dishName = _dishMapper.MapDish(dish);
            var existingDish = retVal.SingleOrDefault(x => x.DishName == dishName);
            if (existingDish == null)
            {
                retVal.Add(new Dish
                {
                    DishName = dishName,
                    Count = 1
                });
            } else if (_dishMapper.IsMultipleAllowed(dish))
            {
                existingDish.Count++;
            }
            else
            {
                throw new ApplicationException(string.Format("Multiple {0}(s) not allowed", dishName));
            }
        }

        private IDishMapper MockedGetDishMapper(TimeOfDay timeOfDay)
        {
            switch(timeOfDay)
            {
                case TimeOfDay.morning:
                    return new MorningDishMapper();
                case TimeOfDay.evening:
                    return new EveningDishMapper();
            }
            throw new ApplicationException("TimeOfDay not found");
        }
    }
}