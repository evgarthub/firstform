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
            
            if (Request.Form != null)
            {
                string[] fieldValue = new string[Request.Form.Count];
                for (int field = 0; field < Request.Form.Count; field++) {
                    fieldValue[field] = Request.Form[field];
                }

                var file = Request.Files.Get("file");
            }
            
            Response.TransmitFile(pageName);


        }
    }
}