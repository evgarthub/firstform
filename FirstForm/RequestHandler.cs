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

            string formDataFile_location_path = context.Server.MapPath("~/uploads/");

            string pageName = Request.PhysicalApplicationPath + Request.CurrentExecutionFilePath;
            
            if (Request.Form.Count > 0)
            {
                IList<string> fieldValues = new List<string>(Request.Form.Count);
                for (int field = 0; field < Request.Form.Count; field++) {
                    fieldValues.Add(Request.Form[field]);
                }
                
                HttpPostedFile file = Request.Files.Get("file");
                fieldValues.Add(file.FileName);

                DatabaseInstanse database = new DatabaseInstanse(fieldValues);
                database.AddValue();

                if (file.ContentLength > 0)
                {
                    file.SaveAs(formDataFile_location_path + file.FileName);
                }
                
            }
            
            Response.TransmitFile(pageName);


        }
    }
}