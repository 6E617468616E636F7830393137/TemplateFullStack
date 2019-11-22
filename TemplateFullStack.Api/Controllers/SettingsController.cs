using Log4net.Helper.Logging;
using TemplateFullStack.Api.Configuration;

namespace TemplateFullStack.Api.Controllers
{
    public class SettingsController : BaseController
    {
        public SettingsController()
            : base()
        {

        }
        public SettingsController(
            ISettings settings)
            : base(settings)
        {
            this.Settings = settings;
            Logger.Info($": : : Calling MainController Constructor : : :");
        }
    }
}
