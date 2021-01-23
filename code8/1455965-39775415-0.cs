    public enum ServerType
    {
        Web,
        Database,
        Bi
    }
    public static class Extensions
    {
        public static bool IsOperational(this ServerType st)
        {
            var operationalTypes  = new List<ServerType> { ServerType.Web, ServerType.Database };
            return operationalTypes.Contains(st);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var st1 = ServerType.Web;
            var st2 = ServerType.Database;
            var st3 = ServerType.Bi;
            bool isSt1Operational = st1.IsOperational();
            bool isSt2Operational = st2.IsOperational();
            bool isSt3Operational = st3.IsOperational();
        }
    }
