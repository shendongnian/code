    private static void GetComponent(string hwclass, string syntax) {
      //DONE: keep query readable
      string query = 
        $@"select * 
             from {hwclass}"; // <- you've missed space here
      //DONE: wrap IDisposable into using
      using (ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", query)) {
        foreach(ManagementObject mj in mos.Get())
          Console.WriteLine(Convert.ToString(mj[syntax]));
      }
    }
