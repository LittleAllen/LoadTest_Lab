using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
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

            Delay();
            return result;
        }

        private void Delay()
        {
            long i = 0;
            Task t = new Task(() =>
            {
                Parallel.For(1, 10000, _ =>
                {
                    for (int j = 0; j < 2; j++)
                    {
                        EncryptAES(Guid.NewGuid().ToString("N"));
                    }
                });

            });

            t.Start();


            Task.WaitAll(t);
        }

        private string EncryptAES(string text)
        {
            string result = "";
            System.Security.Cryptography.AesCryptoServiceProvider provider = new System.Security.Cryptography.AesCryptoServiceProvider();
            provider.IV = Convert.FromBase64String("xJt2LaCGtAQB3+3edKlbaw==");
            provider.Key = Convert.FromBase64String("pJ7JyvLQDPTTIQ4D9x9bZhxrxZY7faGB4Q8PvgmwRrI=");
            provider.Mode = System.Security.Cryptography.CipherMode.CBC;
            provider.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            byte[] dataByteArray = Encoding.Unicode.GetBytes(text);
            // encryption
            using (System.Security.Cryptography.ICryptoTransform encrypt = provider.CreateEncryptor())
            {
                byte[] dest = encrypt.TransformFinalBlock(dataByteArray, 0, dataByteArray.Length);

                // Convert byte array to Base64 strings
                result = Convert.ToBase64String(dest);
            }

            Debug.WriteLine(result);
            return result;
        }
    }
}
