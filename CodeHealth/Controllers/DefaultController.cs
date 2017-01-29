using System.Web.Http;
using System.Xml.Serialization;

namespace CodeHealth.Controllers
{
    public class DefaultController : ApiController
    {
        [HttpGet]
        public IHttpActionResult HelloWorld()
        {
            return Ok(new { foo = "bar" });
        }
    }
}
