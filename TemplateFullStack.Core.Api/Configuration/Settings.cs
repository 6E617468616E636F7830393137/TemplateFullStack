using Microsoft.Extensions.Configuration;
using System;

namespace TemplateFullStack.Core.Api.Configuration
{
    public class Settings : ISettings
    {
        private IConfigurationRoot Configuration { get; set; }
        private IConfigurationSection AppSettings { get; set; }
        public Settings()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            AppSettings = Configuration.GetSection("AppSettings");
            DisableSwagger = AppSettings["DisableSwagger"];
            ErrorObjectIsNull = AppSettings["ErrorObjectIsNull"];
        }
        public string DisableSwagger { get; }
        public Version BuildVersion { get; } = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        public DateTime BuildDate { get; } = Convert.ToDateTime(Properties.Resources.BuildDate);
        public string ErrorObjectIsNull { get; }
    }
}
