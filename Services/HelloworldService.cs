using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Services
{
    public class HelloworldService: IHelloWordService
    {
        public string GetHelloWorld()
        {
            return "Hello World again";
        }
    }

    public interface IHelloWordService
    {
        string GetHelloWorld();
    }
}