using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UserManagementService.Controllers
{
    public class UsersController : ApiController
    {
        [Authorize]
        public IHttpActionResult Get()
        {
            return Ok(new string[] { "User1", "User2" });
        }
    }
}
