    public interface A
    {
        POCO poco { get; set; }
        void MyMethod();
    }
    public class B : A
    {
        public void MyMethod()
        {
            throw new NotImplementedException();
        }
        public POCO poco { get; set; }
    }
    public class C : A
    {
        public void MyMethod()
        {
            throw new NotImplementedException();
        }
        public POCO poco { get; set; }
    }
    public class POCO
    {
        public ulong? id { get; set; }
        public string Name { get; set; }
        public string DeviceType { get; set; }
    }
    public class Program
    {
        public static void main()
        {
            var ctr = TinyIoCContainer.Current;
            ctr.Register<A, B>("B");
            ctr.Register<A, C>("C");
            List<A> devices = new List<A>();
            using (var db = new SqlConnection(Config.DefaultConnectionString))
            {
                db.Open();
                List<POCO> queryResults = db.Query<POCO>("SELECT * FROM Devices").ToList();
                foreach (var queryResult in queryResults)
                {
                    // the magic step where we create the right type of A based on the value in column Name...
                    var newDevice = ctr.Resolve<A>(queryResult.Name);
                    newDevice.poco = queryResult;
                    devices.Add(newDevice);
                }
            }
        }
    }
