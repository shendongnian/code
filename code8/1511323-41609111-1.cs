    public class Language : INotifyPropertyChanged {
    	private string _headerText;
    
    	public string HeaderText {
    		get {
    			return _headerText;
    		}
    
    		set {
    			if (value != _headerText) {
    				_headerText = value;
    				NotifyPropertyChanged();
    			}
    		}
    	}
    }
