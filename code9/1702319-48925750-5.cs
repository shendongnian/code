    public class ViewModel: ViewModelBase
    {
    	
    	protected override Navigate(object param)
    	{
    		//here you navigate 
    	}
    	
    	protected override bool CanExecute()
    	{
    		var result = false;
    		
    		//do whatever you want to return true or false;
    		
    		return result;
    	}
    }
