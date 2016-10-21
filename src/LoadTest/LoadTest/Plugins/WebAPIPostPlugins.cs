using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.WebTesting;

namespace LoadTest.Plugins
{
    [DisplayName("WebAPI post parameter of Name")]
    public class WebApiPostPlugins : WebTestRequestPlugin
    {
        public override void PreRequest(object sender, PreRequestEventArgs e)
        {
            #region -- Plugin PreRequest --

            //FormPostHttpBody formBody = e.Request.Body as FormPostHttpBody;
            //if (formBody == null)
            //{
            //    e.WebTest.AddCommentToResult("formBody is null");
            //    return;
            //}

            //formBody.FormPostParameters.Add("Name", "JamisLiao");

            #endregion

            base.PreRequest(sender, e);
        }
    }
}
