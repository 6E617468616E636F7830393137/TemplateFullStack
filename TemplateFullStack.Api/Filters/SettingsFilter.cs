using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using TemplateFullStack.Api.App_Start;

namespace TemplateFullStack.Api.Filters
{
    public class SettingsFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // Check if filter is enabled
            if (DiContainer.container.Resolve<Configuration.ISettings>().DisableVersionCustomFilter.ToUpper() == "TRUE")
            {
                return;
            }
            // pre-processing
            else
            {

            }
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            // Check if filter is enabled
            if (DiContainer.container.Resolve<Configuration.ISettings>().DisableVersionCustomFilter.ToUpper() == "TRUE")
            {
                return;
            }
            // post-processing
            else
            {

            }
        }
    }
}