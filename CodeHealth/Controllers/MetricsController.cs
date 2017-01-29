using System.Web.Http;

namespace CodeHealth.Controllers
{
    public class MetricsController : ApiController
    {
        public IHttpActionResult Post([FromBody]string value)
        {
            return Ok();
        }
    }
}