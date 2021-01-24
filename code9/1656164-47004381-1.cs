        static void Main(string[] args)
        {
            IContainer container = AutoFacBootstrapper.Init();
            
            IUserHandler startPoint = container.Resolve<IUserHandler>();
            startPoint.PerformSomeAction();
        }
