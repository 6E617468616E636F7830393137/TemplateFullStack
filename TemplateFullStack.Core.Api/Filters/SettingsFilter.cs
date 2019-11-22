using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using TemplateFullStack.Core.Api.Models;
using Logger = Log4Net.Helper.Logging.Core.Logger;
using DI = TemplateFullStack.Core.Api.DependencyInjection.Container;

namespace TemplateFullStack.Core.Api.Filters
{
    public class SettingsFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Logger.Info($": : : : : Settings Filter - OnActionExecuting : : : : :");
            // Setting up a condition where if there are args, then display error
            if (context.ActionArguments.Count > 0)
            {
                DI.container.Resolve<Models.IError>().SetError(DI.container.Resolve<Configuration.ISettings>().ErrorObjectIsNull);
                context.Result = new BadRequestObjectResult(DI.container.Resolve<Models.IError>());
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Logger.Info($": : : : : Settings Filter - OnActionExecuted : : : : :");
        }       
    }
}
