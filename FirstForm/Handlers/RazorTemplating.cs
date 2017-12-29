using FirstForm.Models;
using FirstForm.ViewModels;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Configuration.Xml;
using RazorEngine.Templating;

namespace FirstForm.Handlers
{
    public class RazorTemplating
    {
        public string PageCode { get; private set; }
        public TemplateServiceConfiguration Config { get; set; }
        public IRazorEngineService Service { get; }

        public RazorTemplating(string pageTemplate)
        {
            this.Config = new TemplateServiceConfiguration();
            this.Config.Language = Language.CSharp;
            this.Config.Debug = false;
            this.Config.TemplateManager = new ResolvePathTemplateManager(new string[] {"D:/projects/FirstForm/FirstForm/Views/"});
            this.Service = RazorEngineService.Create(this.Config);
            Engine.Razor = this.Service;

            string template = pageTemplate;

            FormModel formModel = new FormModel();
            Engine.Razor.Compile(template, null);
            this.PageCode = Engine.Razor.Run(Engine.Razor.GetKey(template), null, (object)formModel, null);
        }

        public string GetHtmlString()
        {
            return PageCode;
        }
    }
}