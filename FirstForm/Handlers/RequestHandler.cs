using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstForm.Handlers
{
    public class RequestHandler : IHttpHandler
    {

        public bool IsReusable { get { return false; } }

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;

            string formDataFileLocationPath = context.Server.MapPath("~/uploads/");

            string pageName = Request.PhysicalApplicationPath + Request.CurrentExecutionFilePath;
            
            if (Request.Form.Count > 0)
            {

                FormHandler handleForm = new FormHandler(Request, formDataFileLocationPath);
                
            }
            
            Response.TransmitFile(pageName);

        }
    }
}