    using System.Collections;
    using System.ComponentModel;
    using System.Configuration.Install;
    
    namespace InstallerActions
    {
        [RunInstaller(true)]
        public partial class RemoveFiles : Installer
        {
            protected override void OnAfterUninstall(IDictionary savedState)
            {
                var path = System.IO.Path.Combine(Context.Parameters["path"], "log");
                System.IO.Directory.Delete(path, true);
            }
        }
    }
