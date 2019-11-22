using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateFullStack.Core.Api.Configuration
{
    public interface ISettings
    {
        string DisableSwagger { get; }
        Version BuildVersion { get; }
        DateTime BuildDate { get; }
        string ErrorObjectIsNull { get; }
    }
}
