    public class Exec
    {
        public short vcExtStartUp(ref string Directory, string ExtensionName)
        {
            return 1;
        }
        public short vcExtMenuExec(ref int MenuID)
        {
            Thread thread = new Thread(() =>
            {
                WpfTestAppl.App app = new WpfTestAppl.App();
                // Loading of ResourceAssemblys                
                Assembly resAssembly = Assembly.Load("WPFGlobalResources");
                app.Run(new WpfTestAppl.MainWindow());
                
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            return 1;
        }
    }
