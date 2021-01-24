    class A
    {
        static void Main(string[] args)
        {
            List<RootJson> eList = new List<RootJson>();
            RootJson rootjson = new RootJson();
            Libs.B.Get(rootjson);
        }
    }
    public class B
    {
        public static void Get(RootJson rootJson)
        {
            // Do something if rootJson is null
            if (rootJson == null) rootJson = new RootJson();
            rootJson.Hub = new List<Hub>();
            Hub hub = new Hub();
            hub.OS = "1.1";
            rootJson.Hub.Add(hub);
        }
    }
