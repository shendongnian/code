                string cpuInfo = string.Empty;
                ManagementClass mc = new ManagementClass("win32_processor");
                ManagementObjectCollection moc = mc.GetInstances();
    
                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["processorID"].Value.ToString();
                    break;
                }
