using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoadTest.WebAPI.Models
{
    public class ApiResult
    {
        public TestRequest Data { get; set; }

        public int ResultCode { get; set; }

        public bool IsSuccess { get; set; }
    }
}