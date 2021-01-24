    using System.Runtime.InteropServices;
    ...
    [DllImport("KERNEL32.dll", CharSet = CharSet.Auto, BestFitMapping = false)]
    private extern static int GetComputerName(
      [Out]StringBuilder nameBuffer, 
      ref int bufferSize);
    ...
    int size = 0; // do not try to return any name, but its actual size
    // What's actual size of the machine name?
    GetComputerName(null, ref size);
    // Obtaining the machine name 
    StringBuilder sb = new StringBuilder(size);
    GetComputerName(sb, ref size);
    string name = sb.ToString();
