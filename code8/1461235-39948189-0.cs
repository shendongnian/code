    string HWID = string.Empty;//creating a empty string
    private void Form1_Load(object sender, EventArgs e)
    {
        ManagementClass Management = new ManagementClass("win32_processor");//declaring the system management calss
        ManagementObjectCollection MObject = Management.GetInstances();//decalring the system management object collection 
        foreach (ManagementObject mob in MObject)//having a foreach loop
        {
            if (string.IsNullOrEmpty(HWID))
            {
                HWID = mob.GetPropertyValue("processorID").ToString();//converting the HWID to string
                break;
            }
        }
     }
