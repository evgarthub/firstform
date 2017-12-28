using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstForm.Handlers
{
    public class ThanksHandler : IHttpHandler
    {

        public bool IsReusable { get { return false; } }
        public string PageSource { get; private set; }
        public string PageName { get; private set; }

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;


            string formDataFileLocationPath = context.Server.MapPath("~/uploads/");

            this.PageName = Request.CurrentExecutionFilePath;
            this.PageSource = Request.PhysicalApplicationPath + Request.CurrentExecutionFilePath;

            if (Request.Form.Count > 0)
            {
                FormHandler handleForm = new FormHandler(Request, formDataFileLocationPath);
            }

            RazorTemplating service = new RazorTemplating("thank-you");
            
            Response.Write(service.GetHtmlString());
        }
    }
}