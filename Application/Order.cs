using System.Collections.Generic;

namespace Application
{
    public class Order
    {
        public Order()
        {
            Orders = new List<int>();
        }
        public List<int> Orders { get; set; }
    }
}