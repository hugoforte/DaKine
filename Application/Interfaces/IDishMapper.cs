using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IDishMapper
    {
        string MapDish(int dishType);
        bool IsMultipleAllowed(int dishType);
    }

    public class EveningDishMapper : IDishMapper
    {
        public string MapDish(int dishType)
        {
            return Enum.Parse(typeof(EveningDishes), dishType.ToString()).ToString();
        }

        public bool IsMultipleAllowed(int dishType)
        {
            switch (dishType)
            {
                case 2:
                    return true;
                default:
                    return false;
            }
        }
    }
    public class MorningDishMapper : IDishMapper
    {
        public string MapDish(int dishType)
        {
            return Enum.Parse(typeof(MorningDishes), dishType.ToString()).ToString();
        }

        public bool IsMultipleAllowed(int dishType)
        {
            switch (dishType)
            {
                case 3:
                    return true;
                default:
                    return false;
            }
        }
    }

}
