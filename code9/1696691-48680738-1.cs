    [DllImport("libface.dll" , EntryPoint = "getResults")]
    private static extern IntPtr getResults([MarshalAs(UnmanagedType.LPStr)] string entry);
    static void Main()
    {
      var data = new List<byte>();
     var ptr = getResults("p");
     var off = 0;
     while (true)
     { 
        var ch = Marshal.ReadByte(ptr, off++);
        if (ch == 0)
        {
          break;
        }
        data.Add(ch);
     }
      string sptr = Encoding.UTF8.GetString(data.ToArray());
      Console.WriteLine(sptr);
  
