    [StructLayout(LayoutKind.Sequential)]
    struct MixerCaps
    {
      public ushort ManufacturerID;        
      public ushort ProductId; 
      public int Version;          
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst=32)] 
      public String ProductName;
      public uint Support;
      public uint Destinations;        
      public override String ToString()
      {
     return String.Format("Manufacturer ID: {0}, Product ID: {1}, Driver Version: {2}, Product Name: \"{3}\", Support: {4}, Destinations: {5}", ManufacturerID, ProductId, Version, ProductName, Support, Destinations);
      }
    }
