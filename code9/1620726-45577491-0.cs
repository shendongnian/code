	[StructLayout(LayoutKind.Sequential)]
    public class SSHDDateTime {
      public uint Year { get; set; }     // 
      public uint Month { get; set; }    // 1...12
      public uint Day { get; set; }      // 1...31
      public uint Hour { get; set; }  // 0...23
      public uint Min { get; set; }      // 0...59
      public uint Sec { get; set; }    // 0...59
      public uint MilliSec { get; set; } // 0...999
      public SSHDDateTime() {
        Year = 0;
        Month = 0;
        Day = 0;
        Hour = 0;
        Min = 0;
        Sec = 0;
        MilliSec = 0;
      }
    }
