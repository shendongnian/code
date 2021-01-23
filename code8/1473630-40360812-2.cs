    public class DAL
    {
        public bool ShowMessages { get; set; }
        private StreamWriter logger;
        public DAL() 
        {
            logger = new StreamWriter(....);
        }
    }
    class testmain
    {
        static DAL dal;
        static public void Main(string[] args)
        {
            dal = new DAL();
            dal.ShowMessages = true;
        }
    }
