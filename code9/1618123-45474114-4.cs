        private bool InDesignMode
            {
            get
                {
                return (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) || 
                        base.DesignMode || 
                        (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");
                }
            }
