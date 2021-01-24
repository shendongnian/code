    public class MyRoleEntryPoint: RoleEntryPoint
    {
        public override bool OnStart()
        {
            var name = RoleEnvironment.IsAvailable ? RoleEnvironment.CurrentRoleInstance.Role.Name : "localhost";
            return base.OnStart();
        }
    }
