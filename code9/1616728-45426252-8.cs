    using screensaver.Models;
    using System.Collections.ObjectModel;
    namespace screensaver.ViewModels
    {
	    class ConfigurationViewModel
     	{
		    private readonly ConfigurationModel _model;
		    public ConfigurationViewModel()
		    {
			    _model = new ConfigurationModel();
		    }
		    public ObservableCollection<string> Resolution
		    {
			    get { return _model.Resolution; }
			    set { _model.Resolution = value; }
		    }
    		public string SelectedResolution { get; set; }
	    }
    }
