using System.Collections.Generic;

namespace Application
{
    public interface IDishManager
    {
        List<Dish> GetDishes(List<int> orders);
    }
}