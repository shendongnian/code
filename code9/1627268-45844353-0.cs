        private static void SetAutofacWebAPI()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<IUserService>().As<UserService>().InstancePerRequest();
            builder.RegisterType<IEncryption>().As<Encryption>().InstancePerRequest();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
