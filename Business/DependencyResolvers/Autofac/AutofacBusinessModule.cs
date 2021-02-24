﻿using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.İnterceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>();
            builder.RegisterType<EfCarDal>().As<ICarDal>();
            builder.RegisterType<BrandManager>().As<IBrandService>();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>();
            builder.RegisterType<ColorManager>().As<IColorService>();
            builder.RegisterType<EfColorDal>().As<IColorDal>();
            builder.RegisterType<ModelManager>().As<IModelService>();
            builder.RegisterType<EfModelDal>().As<IModelDal>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();
            builder.RegisterType<RentalManager>().As<IRentalService>();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
