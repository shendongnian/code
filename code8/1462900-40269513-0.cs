    class SMin
    {
      // Just guessing at what type Mgmt is.. replace with your actual class name
      Management mgmt; // Instance passed in via constructor
      public SMin(Dictionary<string, string> conf, Management mgmt)
      {
        this.mgmt = mgmt;
        dat = mgmt.Getbit<bool>(conf["D_BIT"]);
        avg = mgmt.Getbit<bool>(conf["A_BIT"]);
      }
      // Other code
    }
