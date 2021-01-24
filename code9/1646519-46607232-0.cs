    foreach (var theProcess in Process.GetProcesses())
    {
        if (theProcess.ProcessName.ToUpper() == "SVCHOST")
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", string.Format("SELECT * FROM Win32_Service " + "where ProcessId={0}", theProcess.Id));
            foreach (ManagementObject mo in mos.Get())
            {
                Console.WriteLine("Name: " + mo["Name"]);
            }
        }
    }
