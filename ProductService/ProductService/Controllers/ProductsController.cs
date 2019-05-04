using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductService.Controllers
{
    public class ProductsController : ApiController
    {
        [Authorize]
        public IHttpActionResult Get()
        {
            var products = new List<Product>
            {
                new Product{ Id=1, Name="Pro1", Price=10 },
                new Product{ Id=2, Name="Pro2", Price=20 }
            };

            return Ok(products);
        }
    }
}
