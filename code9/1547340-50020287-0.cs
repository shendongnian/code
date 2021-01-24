    public class MyDependantClass
    {
        private readonly Dictionary<string, string> _mobileConfig;
        public MyDependantClass(Dictionary<string, string> mobileConfig)
        {
            _mobileConfig = mobileConfig;
        }
 
        // Use your mobile config here
    }
