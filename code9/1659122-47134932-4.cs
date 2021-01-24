    public partial class ErrorLog
    {
        public  string getErrorDescription()
        {
            return d[(int)error];
        }
        private static Dictionary<int, string> d = new Dictionary<int, string>()
        {
            {1,"desc1" },
            {2,"desc2" },
            {3,"desc3" },
            {4,"desc4" }
        };
    }
