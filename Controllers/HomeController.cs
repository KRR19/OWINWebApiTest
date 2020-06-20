using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
namespace OWINWebApi.Controllers
{
    public class HomeController : ApiController
    {
        public IEnumerable<int> GetVAlues()
        {
            return Enumerable.Range(0,10);
        }
    }
}