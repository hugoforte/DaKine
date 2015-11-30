using System.Collections.Generic;

namespace Application
{
    public class Order
    {
        public Order()
        {
            OrderTypes = new List<int>();
        }

        public List<int> OrderTypes { get; set; }
    }
}