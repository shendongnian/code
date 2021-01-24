    public class SchoolSelectionViewModel : BaseViewModel
    {
    	public void DoSelectItem(SchoolModel item)
    	{
    		ShowViewModel<LoginViewModel, SchoolModel>(item);
    	}
    }
    
    public class LoginViewModel : BaseViewModel<SchoolModel>
    {
    	private SchoolModel _parameter;
    
    	public override Task Prepare(SchoolModel parameter)
    	{
    		// receive and store the parameter here
    		_parameter = parameter;
    	}
    }
