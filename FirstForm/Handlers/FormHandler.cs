using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace FirstForm.Handlers
{
    public class FormHandler
    {
        public FormHandler(HttpRequest request, string filePath)
        {
            HttpPostedFile file = request.Files.Get("file");
            string uploadedFileName = file.FileName;

            DatabaseInstanse database = new DatabaseInstanse(request.Form, uploadedFileName);

            if (!database.CheckRecord("email = @email AND surname = @surname"))
            {
                database.AddValue();
            }
            else
            {
                database.UpdateValue();
            }


            if (file.ContentLength > 0)
            {
                file.SaveAs(filePath + file.FileName);
            }
        }

    }
}
