    public sealed class IpAndPort
    {
        public string Ip { get; private set; }
        public string Port { get; private set; }
        public IpAndPort (string ip, string port)
        {
            Ip = ip;
            Port = port;
        }
    }
    var list = new List<IpAndPort>();
    foreach(var line in File.ReadLines(FileName))
    {
        var temp = line.Split(':');
        list.Add(new IpAndPort(temp[0], temp[1]);
    }
