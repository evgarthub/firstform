using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace FirstForm
{
    public class RequestHandler : IHttpHandler
    {

        public bool IsReusable { get { return false; } }

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;

            string pageName = Request.PhysicalApplicationPath + Request.CurrentExecutionFilePath;

            NameValueCollection formValue;
            if (Request.Form != null)
            {
                formValue = Request.Form;
                var fileUpload = Request.Form["file"];
            }

            Response.TransmitFile(pageName);


        }
    }
}