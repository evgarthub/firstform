using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace FirstForm.Models
{
    public class FormModel
    {
        public string DataName { get; private set; }

        public string DataEmail { get; private set; }

        public string DataSurname { get; private set; }

        public string DataFileName { get; private set; }

        public FormModel(NameValueCollection formDataCollection)
        {
            this.DataName = formDataCollection["name"];
            this.DataEmail = formDataCollection["email"];
            this.DataSurname = formDataCollection["surname"];
        }

        public FormModel()
        {

        }
    }
}