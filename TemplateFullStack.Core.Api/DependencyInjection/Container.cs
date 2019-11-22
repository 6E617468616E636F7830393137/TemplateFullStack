using Autofac;

namespace TemplateFullStack.Core.Api.DependencyInjection
{
    public class Container
    {
        // Create Container Object
        public static ContainerBuilder builder;
        public static IContainer container;
        public static void Initialize()
        {
            // Instantiate Container Object
            builder = new ContainerBuilder();

            // Register Dynamic Services
            // var service = Assembly.Load("<DLL_NAME>");
            // builder.RegisterAssemblyTypes(service)
            //    .AsImplementedInterfaces();
            //
            // Register BLL Types
            //builder.RegisterType<Bll.Values.ValuesService>()
            //    .As<Bll.Values.IValuesService>()
            //    .InstancePerLifetimeScope();
            // Register Settings            
            builder.Register(c => new Configuration.Settings())
                .As<Configuration.ISettings>()
                .InstancePerLifetimeScope();
            builder.Register(c => new Models.Error())
                .As<Models.IError>()
                .InstancePerLifetimeScope();
            //builder.Register(c => new ValuesService(c.Resolve<ILogger<ValuesService>>()))
            //    .As<IValuesService>()
            //    .InstancePerLifetimeScope();
            container = builder.Build();
        }
    }
}
