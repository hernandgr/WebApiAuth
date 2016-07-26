using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using HMACAuthentication.Api.Filters;
using HMACAuthentication.Api.Models;

namespace HMACAuthentication.Api.Controllers
{
    [HMACAuthentication]
    [RoutePrefix("api/Orders")]
    public class OrdersController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;

            var Name = ClaimsPrincipal.Current.Identity.Name;

            return Ok(Order.CreateOrders());
        }

        [Route("")]
        public IHttpActionResult Post(Order order)
        {
            return Ok(order);
        }

    }
}