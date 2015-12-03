using System.Collections.Generic;

namespace Application
{
    public interface IDishManager
    {
        List<Dish> GetDishes(Order order);
    }
}