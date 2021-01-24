    public interface ISettingProvider
    {
    	double Volumne { get; set; }
    	string LastMediaUrl { get; set; }
    	MediaStatus PlayingMediaStatus;
    	
    	void SaveSettings();
    }
