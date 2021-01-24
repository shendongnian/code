    [Guid("xx")]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface StudentItem
    {
        string Type { get; set; }
        DateTime Week { get; set; }
        int Study { get; set; }
    }
