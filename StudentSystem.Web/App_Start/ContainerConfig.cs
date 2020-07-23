using Autofac;
using Autofac.Integration.Mvc;
using StudentsSystem.Data.Models;
using StudentsSystem.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem.Web.App_Start
{
    public class ContainerConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<StudentData>().As<IStudentData>().InstancePerRequest();
            builder.RegisterType<ArmyTechDB>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}