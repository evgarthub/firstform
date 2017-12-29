using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstForm.Handlers;

namespace FirstForm.ViewModels
{
    public class FormDataBase
    {
        public string DataName { get; private set; }

        public string DataEmail { get; private set; }

        public string DataSurname { get; private set; }

        public string DataFileName { get; private set; }

        public FormDataBase()
        {
            this.DataName = "TestStaticName";
        }
    }
}