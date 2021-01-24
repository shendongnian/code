    static void Main(string[] args)
    {
        IUnityContainer objconatiner = new UnityContainer();
        objconatiner.RegisterType<Customer>();
        objconatiner.RegisterType<IDal, SqlserverDal>("SqlServer");
        objconatiner.RegisterType<IDal, OracleServerDal>("Oracle");
        Customer ocust = objconatiner.Resolve<Customer>();
        ocust.CustName = "Taylor Swift";
        ocust.Add();
    }
    public class Customer
    {
        private IDal oidal;
        public string CustName { get; set; }
    
        public Customer([Dependency("SqlServer")]IDal idal)
        {
            oidal = idal;
        }
    
        public void Add()
        {
            oidal.Add();
        }
    }
