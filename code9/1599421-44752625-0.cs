        public class MainViewModel
    	{
    		private readonly IPlatform _platform;
    		private readonly ISettings _settings;
            private readonly IContextUtility _contextUtility;
    
    		public MainViewModel (IPlatform platform, ISettings settings,IContextUtility contextUtility)
    		{
    			_settings = settings;
    			_platform = platform;
                _contextUtility = contextUtility;
            }
    
            public string Abc
            {
                get {
                    return _contextUtility.GetAssetTxt("abc.txt");
                }
            }
          ...
        }
