    public class UnityWebApiActivator
    {
        public static void Start()
        {
            while (!RoleEnvironment.IsAvailable)
            {
                Thread.Sleep(100);
            }
            var name =  RoleEnvironment.CurrentRoleInstance.Role.Name;
        }
    }
