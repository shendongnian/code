    public partial class App : Application
    {
        public App()
        {
            Startup += Application_Startup;
            Exit += Application_Exit;
            InitializeComponent();
        }
        /// <summary>
        /// Detect if the local machine is a virtual or a physical one
        /// </summary>
        /// <returns>True if the local machine is virtual, False if the local machine is physical</returns>
        private bool IsVirtualMachine()
        {
            using (var searcher = new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem"))
            {
                using (var items = searcher.Get())
                {
                    foreach (var item in items)
                    {
                        string manufacturer = item["Manufacturer"].ToString().ToLower();
                        if ((manufacturer == "microsoft corporation" && item["Model"].ToString().ToUpperInvariant().Contains("VIRTUAL"))
                            || manufacturer.Contains("vmware")
                            || item["Model"].ToString() == "VirtualBox")
                        {
                            return true;
                        }
                        // Check "HypervisorPresent" property, which is available in some cases.
                        var hypervisorPresentProperty
                          = item.Properties
                                .OfType<PropertyData>()
                                .FirstOrDefault(p => p.Name == "HypervisorPresent");
                        if ((bool?)hypervisorPresentProperty?.Value == true)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
       private void Application_Startup(object sender, StartupEventArgs e)
        {
            //Alter the rendering for the virtual machine (see Bug 
            if (this.IsVirtualMachine())
                RenderOptions.ProcessRenderMode = System.Windows.Interop.RenderMode.SoftwareOnly;
            else
                RenderOptions.ProcessRenderMode = System.Windows.Interop.RenderMode.Default;
        }
    }
