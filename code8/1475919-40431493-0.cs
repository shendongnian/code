    [RunInstaller(true)]
    public class CustomInstaller : System.Configuration.Install.Installer
    {
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            //this.Context.Parameters contains the command line arguments
        }
    }
