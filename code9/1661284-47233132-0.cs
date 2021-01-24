    public static class SandBox
    {
        public static AppDomain CreateSandboxDomain(string name, string path, SecurityZone zone)
        {
            string fullDirectory = Path.GetFullPath(path);
            string cachePath = Path.Combine(fullDirectory, "ShadowCopyCache");
            string pluginPath = Path.Combine(fullDirectory, "Plugins");
            if (!Directory.Exists(cachePath))
                Directory.CreateDirectory(cachePath);
            if (!Directory.Exists(pluginPath))
                Directory.CreateDirectory(pluginPath);
            AppDomainSetup setup = new AppDomainSetup
            {
                ApplicationBase = fullDirectory,
                CachePath = cachePath,
                ShadowCopyDirectories = pluginPath,
                ShadowCopyFiles = "true"
            };
            Evidence evidence = new Evidence();
            evidence.AddHostEvidence(new Zone(zone));
            PermissionSet permissions = SecurityManager.GetStandardSandbox(evidence);
            return AppDomain.CreateDomain(name, evidence, setup, permissions);
        }
    }
    public class Runner : MarshalByRefObject
    {
        private CompositionContainer _container;
        private DirectoryCatalog _directoryCatalog;
        private readonly AggregateCatalog _catalog = new AggregateCatalog();
        public bool CanExport<T>()
        {
            T result = _container.GetExportedValueOrDefault<T>();
            return result != null;
        }
        public void Recompose()
        {
            _directoryCatalog.Refresh();
            _container.ComposeParts(_directoryCatalog.Parts);
        }
        public void RunAction(Action codeToExecute)
        {
            MefBase.Container = _container;
            codeToExecute.Invoke();
        }
        public void CreateMefContainer()
        {
            RegistrationBuilder regBuilder = new RegistrationBuilder();
            string pluginPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            _directoryCatalog = new DirectoryCatalog(pluginPath, regBuilder);
            _catalog.Catalogs.Add(_directoryCatalog);
            _container = new CompositionContainer(_catalog, true);
            _container.ComposeExportedValue(_container);
            Console.WriteLine("exports in AppDomain {0}", AppDomain.CurrentDomain.FriendlyName);
        }
    }
