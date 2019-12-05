using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DLMIS.Authenticator;
using DLMIS.Global;

namespace lcweb.Controllers
{
    public class LcController : ApiController //DLBaseApiController
    {
        [HttpGet]
        public Info GetInfo()
        {
            Info info = new Info
            {
                Id = DLExpressionHelper.Instance.Format("$Session.UserId"),
                Name = "张三",
                Age = 22
            };
            return info;
        }
        public class Info
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}