using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using TemplateFullStack.Core.Api.Filters;

namespace TemplateFullStack.Core.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            // Initialize Logger
            Log4Net.Helper.Logging.Core.Logger.Initialize();
            // Initialize Autofac
            DependencyInjection.Container.Initialize();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddControllers();
            //services.AddMvc(options => { options.Filters.Add(new SettingsFilter()); });
            services.AddScoped<SettingsFilter>();
            services.AddCors(options => { 
                options.AddPolicy("AllowAllOrigin", builder => { 
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials(); 
                }); 
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TemplateFullStack.Core.Api",
                    Version = "v1",
                    Description = "A template for ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    { 
                        Name = "Nathan",
                        Email = string.Empty,
                        Url = new Uri("http://www.thecomputerscientist.net"),
                    },
                    License = new OpenApiLicense
                    { 
                        Name = "Use under lincense",
                        Url = new Uri("https://example.com/license"),
                    }
                }); 
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });                        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TemplateFullStack.Core.Api V1");
                c.RoutePrefix = "swagger";
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
