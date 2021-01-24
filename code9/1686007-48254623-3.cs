    public class SchoolSelectionViewModel : BaseViewModel
    {
    	public void DoSelectItem(SchoolModel item)
    	{
    		ShowViewModel<LoginViewModel>(item);
    	}
    }
    
    public class LoginViewModel : BaseViewModel
    {
    	private SchoolModel _parameter;
    
    	public override void Init(SchoolModel parameter)
    	{
    		// receive and store the parameter here
    		_parameter = parameter;
    	}
    }
