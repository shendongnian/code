    public class Launcher : MarshalByRefObject
    {
        public void Start(byte[] Exe, string[] args)
        {
            PermissionSet ps = new PermissionSet(PermissionState.Unrestricted);
            AppDomainSetup setup = new AppDomainSetup();
            setup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
            Evidence ev = new Evidence();
            AppDomain appDomain = AppDomain.CreateDomain("Sandbox",
                ev,
                setup,
                ps);
            Launcher program = (Launcher)appDomain.CreateInstanceAndUnwrap(
                typeof(Launcher).Assembly.FullName,
                typeof(Launcher).FullName);
            program.Execute(Exe, new object[] { args });
            AppDomain.Unload(appDomain);
        }
        public void Execute(byte[] bytes, object[] args)
        {
            Assembly assembly = Assembly.Load(bytes);
            MethodInfo main = assembly.EntryPoint;
            main.Invoke(null, args);
        }
    }
