using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.WebTesting;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace LoadTest.Validats
{
    [DisplayName("Result Code Validat")]
    [Description("驗證ResultCode是否正確")]
    public class ResultCodeValidat : ValidationRule
    {
        public string RequiredTagName { get; set; }

        private string _resultCode;

        public override void Validate(object sender, ValidationEventArgs e)
        {
            #region -- Validat --

            //bool validated = false;

            //var jsonString = e.Response.BodyString;
            //var json = JObject.Parse(jsonString);
            //this._resultCode = json.SelectToken(RequiredTagName).ToString();
            //if(this._resultCode == "200")
            //{
            //    validated = true;
            //}

            //e.IsValid = validated;

            //if (!validated)
            //{
            //    e.Message = string.Format("ResultCode : {0}", this._resultCode);
            //}

            #endregion
        }
    }
}
