using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Server : IServer
    {
        public string TakeOrder(string order)
        {
            throw new NotImplementedException();
        }
    }

    public interface IServer
    {
        string TakeOrder(string order);

    }
}
