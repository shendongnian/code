    namespace Project.ServiceLayer {
        public static class DryIocExtesnions {
            public static void AddServiceLayer(this IContainer c) {
                c.Register<IUserRepository, UserRepository>();        
                c.Register<IOtherRepository, OtherRepository>();
            }
        }
    }
