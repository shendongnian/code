    public partial class SomeView : Window
    {
    	public DiscImageView()
    	{
    		//	...
    
    		viewModel.PropertyChanged += ViewModel_PropertyChanged;
    	}
    
    	private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    	{
    		if (e.PropertyName == nameof(SomeViewModel.SomeProperty))
    		{
    			//	Logic for changed property event
    		}
    	}
    }
