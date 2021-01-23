    public class MainVm
    {
    	private SelectedObject _Selected ;
    	public SelectedObject Selected
    	{
    		get { return _Selected ; }
    		set 
            { 
               _Selected = value; 
               PropertyChanged(this, new PropertyChangedEventArgs("Selected"));
            }
    	}
    //...
    }
