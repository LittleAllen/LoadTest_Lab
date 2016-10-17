using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoadTest.WebAPI.Models;

namespace LoadTest.WebAPI.Controllers
{
    public class TestController : ApiController
    {
        public string Get()
        {
            return "This is Get method";
        }

        public ApiResult Post(TestRequest request)
        {
            var result = new ApiResult()
            {
                Data = new TestRequest()
                {
                    Echo = request.Echo,
                    Name = request.Name + " from server."
                },
                ResultCode = 200,
                IsSuccess = true
            };

            return result;
        }
    }
}
