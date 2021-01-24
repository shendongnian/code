    interface IUserHandler
    {
        void PerformSomeAction();
    }
    class UserHandler : IUserHandler
    {
        private IBackupFactory _backupFactory;
        public UserHandler(IBackupFactory backupFactory)
        {
            _backupFactory = backupFactory;
        }
        public void PerformSomeAction()
        {
            var users = _backupFactory.GetFtpUsers();
        }
    }
    class AutoFacBootstrapper
    {
        public static IContainer Init()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UserHandler>().As<IUserHandler>();
            builder.RegisterType<BackupFactory>().As<IBackupFactory>();
            return builder.Build();
        }
    }
