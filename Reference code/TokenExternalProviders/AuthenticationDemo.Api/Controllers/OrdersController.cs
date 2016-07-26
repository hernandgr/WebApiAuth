using System.Collections.Generic;
using System.Web.Http;

namespace AuthenticationDemo.Api.Controllers
{
    [RoutePrefix("api/Orders")]
    public class OrdersController : ApiController
    {
        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            var orders = new List<Order>
            {
                new Order {OrderId = 1, CustomerName = "Hernan", IsShipped = true, ShipperCity = "Medellín"},
                new Order {OrderId = 2, CustomerName = "David", IsShipped = false, ShipperCity = "Bogotá"}
            };

            return Ok(orders);
        }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string ShipperCity { get; set; }
        public bool IsShipped { get; set; }
    }
}