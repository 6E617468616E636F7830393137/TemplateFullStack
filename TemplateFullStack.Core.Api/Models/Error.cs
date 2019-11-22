using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DI = TemplateFullStack.Core.Api.DependencyInjection.Container;

namespace TemplateFullStack.Core.Api.Models
{
    public class Error : IError
    {
        public Error()
        {
            this.error = null;
        }
        public void SetError(string message)
        {
            this.error = message;
        }
        public string error { get; set; }

        //public string ErrorObjectIsNull { get { return this.error = DI.container.Resolve<Configuration.ISettings>().ErrorObjectIsNull; } }
    }
}
