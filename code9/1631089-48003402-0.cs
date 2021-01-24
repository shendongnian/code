        protected override void Load(ContainerBuilder builder)
        {
			...
            bool executeLocal = false;
            var executeLocalObj = Thread.GetData(Thread.GetNamedDataSlot("ExecuteLocal"));
            if (executeLocalObj != null)
            {
                executeLocal = (bool)executeLocalObj;
            }
            if (executeLocal)
            {
                builder.RegisterModule(new mpm.seg.Common.Database.AutofacModules.NHibernateComponentModule());
                builder.RegisterModule(Activator.CreateInstance(Type.GetType("assembly1.ComponentModule, assembly1")) as IModule);
                builder.RegisterModule(Activator.CreateInstance(Type.GetType("assembly2.AutofacModules.ComponentModule, assembly1")) as IModule);
                builder.RegisterModule(Activator.CreateInstance(Type.GetType("assembly3.AutofacModules.ComponentModule, assembly3")) as IModule);
                builder.RegisterModule(Activator.CreateInstance(Type.GetType("assembly4.AutofacModules.ComponentModule, assembly4")) as IModule);
                builder.RegisterModule(Activator.CreateInstance(Type.GetType("assembly5.AutofacModules.ComponentModule, assembly5")) as IModule);
                builder.RegisterModule(new assembly6.AutofacModules.NHibernateComponentModule() { DatabaseConfigurationSectionName = "databaseSettings" });
                builder.RegisterModule(Activator.CreateInstance(Type.GetType("assembly7.AutofacModules.ComponentModule, assembly7")) as IModule);
                builder.RegisterModule(Activator.CreateInstance(Type.GetType("assembly8.AutofacModules.ComponentModule, assembly8")) as IModule);
                builder.RegisterModule(Activator.CreateInstance(Type.GetType("assembly9.AutofacModules.ComponentModule, assembly9")) as IModule);
            }
        }
