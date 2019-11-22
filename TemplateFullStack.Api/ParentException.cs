﻿using System;
using System.Web.Http.ExceptionHandling;
using Logger = Log4net.Helper.Logging.Logger;

namespace TemplateFullStack.Api
{
    public class ParentExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            try
            {
                Logger.Fatal($"Unhandled exception occurred on server '{Environment.MachineName}' while processing {context.Request.Method.ToString()} for {context.Request.RequestUri.ToString()}", context.Exception);
            }
            catch (Exception ex)
            {
                Logger.Fatal($"Unhandled exception occurred on server '{Environment.MachineName}'", ex);
            }
        }
    }
}