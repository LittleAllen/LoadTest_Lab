using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.WebTesting;
using Newtonsoft.Json.Linq;

namespace LoadTest.Rules
{
    [DisplayName("Extract Echo")]
    public class TestResultExtractEchoRule : ExtractionRule
    {
        public string ExtractEcho { get; set; }

        public override void Extract(object sender, ExtractionEventArgs e)
        {
            var jsonString = e.Response.BodyString;
            var json = JObject.Parse(jsonString);
            JToken jToken = null;
            if (json == null)
            {
                e.Success = false;
                e.Message = "無法解析回傳的 JSON 資料";
            }
            else
            {
                jToken = json.SelectToken("ResultCode");
                if (jToken == null || !jToken.ToString().Equals("200"))
                {
                    e.Success = false;
                    e.Message = String.Format("回傳訊息的 Result Code 不為 200，目前為 {0}。目前回傳的資料為: {1}", jToken.ToString(), jsonString);
                    return;
                }
                jToken = json.SelectToken("Data").SelectToken("Echo");
                if (jToken == null)
                {
                    e.Success = false;
                    e.Message = String.Format("在回傳的 Json 資料中，找不到 Token: {0}。目前回傳的資料為: {1}", this.ExtractEcho, jsonString);
                }
                else
                {
                    e.Success = true;
                    e.WebTest.Context.Add(this.ContextParameterName, jToken);
                }
            }
        }
    }
}
