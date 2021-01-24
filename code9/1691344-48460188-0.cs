    public class TcpProcessRecord
    {
        [DisplayName("Local Address")]
         public IPAddress LocalAddress { get; set; }
         [DisplayName("Local Port")]
         public ushort LocalPort { get; set; }
         [DisplayName("Remote Address")]
         public IPAddress RemoteAddress { get; set; }
         [DisplayName("Remote Port")]
         public ushort RemotePort { get; set; }
         [DisplayName("State")]
         public MibTcpState State { get; set; }
         [DisplayName("Process ID")]
         public int ProcessId { get; set; }
         [DisplayName("Process Name")]
         public string ProcessName { get; set; }
    }
