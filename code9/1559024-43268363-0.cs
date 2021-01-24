        /// <summary>
        /// Return processorId from first CPU in machine
        /// </summary>
        /// <returns>[string] ProcessorId</returns>
        public string GetCPUId()
        {
            string cpuInfo =  String.Empty;
            string temp=String.Empty;
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach(ManagementObject mo in moc)
            {
                if(cpuInfo==String.Empty) 
                {// only return cpuInfo from first CPU
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                }             
            }
            return cpuInfo;
        }
