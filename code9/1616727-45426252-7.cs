    using System.Collections.ObjectModel;
    namespace screensaver.Models
    {
	    class ConfigurationModel
	    {
		    public ObservableCollection<string> Resolution
		    {
			    get;
			    set;
		    }
		    public ConfigurationModel()
		    {
		     	Resolution = new ObservableCollection<string>() {
				    "360 * 720",
				    "720 * 1080",
				    "1080 * 2060"
			    };
		    }
	    }
    }
