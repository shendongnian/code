    public class SettingProvider : ISettingProvider
    {
    	private double volumne;
        public double Volumne  // read-write instance property
        {
            get
            {
                return volumne;
            }
            set
            {
                volumne = value;
    			Settings.Default.Volumne = volumne;
            }
        }
    	
    	private string lastMediaUrl;
        public string LastMediaUrl  // read-write instance property
        {
            get
            {
                return lastMediaUrl;
            }
            set
            {
                lastMediaUrl = value;
    			Settings.Default.LastMediaUrl = lastMediaUrl;
            }
        }
    	
    	private MediaStatus playingMediaStatus;
        public MediaStatus PlayingMediaStatus  // read-write instance property
        {
            get
            {
                return playingMediaStatus;
            }
            set
            {
                playingMediaStatus = value;
    			Settings.Default.PlayingMediaStatus = (int)playingMediaStatus;
            }
        }
    	
    	public void SaveSettings()
    	{
    		Settings.Default.Save();
    	}
    	
    	//Constructor
    	public SettingProvider()
    	{
    		this.Volumne = Settings.Default.Volumne;
    		this.LastMediaUrl = Settings.Default.LastMediaUrl;
    		this.PlayingMediaStatus = (MediaStatus)Settings.Default.PlayingMediaStatus;
    		
    	}
    }
