using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace FirstForm
{
    public class FormHandler : RequestHandler
    {

        NameValueCollection formValue;

        public object Request { get; private set; }

        public void FormRequest(HttpContext context)
        {
           
        }
        
    }
}
