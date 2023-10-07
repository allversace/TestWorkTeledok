using WebApplication2.Interface;
using WebApplication2.Models;

namespace WebApplication2.ModelsAPI
{
    public class ClientAPI : Client, IClientAPI
    {
        public string GetClientInfo()
        {
            return $"{Name}";
        }
    }
}
