    container.RegisterType<IRoleClient, RoleClient>("SomeRegisterName", ReuseWithinResolve, new InjectionConstructor(Config.ApiUrl, "/api/adminRoles"));
 
    ....
    public class AdminRoleController()
    {
        private readonly IRoleClient _roleClient;
        public AdminRoleController([Dependency("SomeRegisterName")]IRoleClient roleClient)
        {
            _roleClient = roleClient;
        }
    }
