    public sealed class Module
    {
        public static Module None { get; } = new Module(SubModule.None);
        public static Module Authentication { get; } = new Module(SubModule.Login);
        public static Module User { get; } = new Module(SubModule.User, SubModule.ForgotPassword, SubModule.ResetPassword);
        private SubModule[] _subModules;
        private Module(params SubModule[] subModules)
        {
            _subModules = subModules;
        }
    }
