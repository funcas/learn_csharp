using System;
using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using demo.Filters;
using demo.Services;

namespace demo
{
    public class AutofacModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //var IAppServices = Assembly.Load("demo");
            var AppServices = Assembly.Load("demo");
            builder.RegisterType<TransactionalInterceptor>();
            builder.RegisterAssemblyTypes(AppServices)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(TransactionalInterceptor)); ;
            
        }
    }
}

