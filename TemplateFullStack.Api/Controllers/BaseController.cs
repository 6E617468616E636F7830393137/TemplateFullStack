using Autofac;
using System.Web.Http;
using TemplateFullStack.Api.App_Start;
using TemplateFullStack.Api.Configuration;

namespace TemplateFullStack.Api.Controllers
{    
    [RoutePrefix("api")]
    public class BaseController : ApiController
    {
        public Configuration.ISettings Settings { get; set; }
        public BaseController()
        {
            this.Settings = DiContainer.container.Resolve<ISettings>();
        }
        public BaseController(ISettings settings)
        {
            Settings = settings;
        }
    }
    
}
