    public class MyModelVm : BaseViewModel //whatever base class you use to notify of property changes.
    {
    	public MyModelVm(MyModel model, MyViewModel parentViewModel)
    	{
    		Model = model;
    		ParentViewModel = parentViewModel;
    	}
    
    	public MyModel Model { get; }
    	public MyViewModel ParentViewModel { get; }
    
    	public string Data
    	{
    		get { return Model.Data; }
    		set
    		{
    			if (ParentViewModel.models.Any(x => x != this && x.Data == this.Data))
    			{
    				//Duplicate entered
    			}
    			else
    			{
    				//Not a duplicate, go ahead and allow the change.
    				Model.Data = value;
                    //don't forget to notify of property change!
    			}
    		}
    	}
    }
