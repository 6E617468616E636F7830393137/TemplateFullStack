using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using TemplateFullStack.Core.Api.Filters;
using Logger = Log4Net.Helper.Logging.Core.Logger;
using DI = TemplateFullStack.Core.Api.DependencyInjection.Container;
namespace TemplateFullStack.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        /// <summary>Gets swagger setting for API.</summary>
        /// <remarks>Gets swagger setting for API.
        /// <br />
        /// No Request Model
        /// 
        /// </remarks>
        /// <retuns></retuns>
        /// <response code = "400" > Bad Request</response>
        /// <response code = "404" > Not Found</response>
        /// <response code = "500" > Internal Server Error</response>        
        // GET api/values
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        // Get api/swaggersetting
        [Route("swaggersetting")]
        [ServiceFilter(typeof(SettingsFilter))]
        [HttpGet]
        public async IAsyncEnumerable<string> GetDisableSwaggerSetting()
        {
            Logger.Info($"API - ENDPOINT :: SWAGGERSETTING :: {DependencyInjection.Container.container.Resolve<Configuration.ISettings>().DisableSwagger}");
            var result = await Task.Run(() => DI.container.Resolve<Configuration.ISettings>().DisableSwagger);
            yield return result;
        }
        /// <summary>Gets version for API.</summary>
        /// <remarks>Gets version for API.
        /// <br />
        /// No Request Model
        /// 
        /// </remarks>
        /// <retuns></retuns>
        /// <response code = "400" > Bad Request</response>
        /// <response code = "404" > Not Found</response>
        /// <response code = "500" > Internal Server Error</response>        
        // GET api/values
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        // Get api/version
        [Route("version")]
        [HttpGet]
        public async Task<IActionResult> GetVersion()
        {
            var result = await Task.Run(() => DependencyInjection.Container.container.Resolve<Configuration.ISettings>().BuildVersion);
            return Ok(result);
        }
        /// <summary>Gets build date for API.</summary>
        /// <remarks>Gets build date for API.
        /// <br />
        /// No Request Model
        /// 
        /// </remarks>
        /// <retuns></retuns>
        /// <response code = "400" > Bad Request</response>
        /// <response code = "404" > Not Found</response>
        /// <response code = "500" > Internal Server Error</response>        
        // GET api/values
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        // Get api/build
        [Route("build")]
        [HttpGet]
        public async Task<IActionResult> GetBuildDate()
        {
            Logger.Info($"API - ENDPOINT :: BUILD DATE/TIME :: {DependencyInjection.Container.container.Resolve<Configuration.ISettings>().BuildDate}");
            var result = await Task.Run(() => DependencyInjection.Container.container.Resolve<Configuration.ISettings>().BuildDate);
            return Ok(result);
        }
    }
}