    public class ViewModel1 : BaseViewModel
    {
    	private ObservableCollection<string> logs;
    	public ObservableCollection<string> Logs {
    		get {
    			if (logs == null)
    				logs = new ObservableCollection<string>();
    			return logs;
    		}
    	}
    
    	// This is added for test
    	public void AddLogEntry() {
    		Logs.Insert(0, DateTime.Now.ToString());
    	}
    }
