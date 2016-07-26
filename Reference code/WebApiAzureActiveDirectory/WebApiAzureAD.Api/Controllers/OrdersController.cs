using System.Collections.Generic;
using System.Web.Http;
using WebApiAzureAD.Api.Models;

namespace WebApiAzureAD.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            var isAuth = User.Identity.IsAuthenticated;
            var userName = User.Identity.Name;

            return Ok(GetOrders());
        }

        private List<Order> GetOrders()
        {
            return new List<Order>
            {
                new Order {OrderId = 10248, CustomerName = "Taiseer Joudeh", ShipperCity = "Amman", IsShipped = true},
                new Order {OrderId = 10249, CustomerName = "Ahmad Hasan", ShipperCity = "Dubai", IsShipped = false},
                new Order {OrderId = 10250, CustomerName = "Tamer Yaser", ShipperCity = "Jeddah", IsShipped = false},
                new Order {OrderId = 10251, CustomerName = "Lina Majed", ShipperCity = "Abu Dhabi", IsShipped = false},
                new Order {OrderId = 10252, CustomerName = "Yasmeen Rami", ShipperCity = "Kuwait", IsShipped = true}
            };
        }
    }
}