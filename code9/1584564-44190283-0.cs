	[ImplementPropertyChanged]
	public class MySettings
	{
        public string Url {
			get { return Settings.Url; } // These are yours "Settings"
			set { Settings.Url = value; }
		}
		public int Port {
			get { return Settings.Port; }
			set { Settings.Port = value; }
		}
    } 
