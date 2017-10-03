using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using System.Web.Mvc;
using Unity.Mvc5;
using Recrutamento.Negocio;
using Recrutamento.Dados;

namespace Recrutamento.Visao
{
    public class Bootstrapper
    {
        private static IUnityContainer container;

        public static void Initialize()
        {
            container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            container = new UnityContainer();

            RegisterTypes();

            return container;
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }
        //    private static void RegisterServiceWithPerformanceAndCachingDecorators<T>(IUnityContainer container,
        //Func<IUnityContainer, T> func)
        //    {
        //        Func<IUnityContainer, Object> createWithDecoratorsFunc = c =>
        //            PerformanceCounterProxy<T>.Create(
        //                CachingDynamicProxy<T>.Create(
        //                    func(c),
        //                    c.Resolve<ICaching>()
        //                    ));

        //        container.RegisterType<T>(new InjectionFactory(createWithDecoratorsFunc));
        //    }

        //public class NullAuditProcessor : IAuditProcessor
        //{
        //    public void Process(IAuditableContext context)
        //    {
        //    }
        //}


        private static void RegisterTypes()
        {
            container.RegisterType<IDataContextFactory, DataContextFactory>(new ContainerControlledLifetimeManager());
            container.RegisterType<IGerenciar, Gerenciar>(new ContainerControlledLifetimeManager());
            container.RegisterType<IRepositorioDAL, RepositorioDAL>(new ContainerControlledLifetimeManager());
        }

    }
}