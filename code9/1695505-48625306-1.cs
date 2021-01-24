    public class NonMainWindowVM : INotifyPropertyChanged
    {
    	public NonMainWindowVM(MainWindowVM mwVM)
    	{
    		mwVM.PropertyChanged += MW_PropertyChanged;
    	}
    	private void MW_PropertyChanged(object sender, PropertyChangedEventArgs e)
    	{
    		switch (e.PropertyName)
    		{
    			case nameof(MainWindowVM.ID):
    				//logic MainWindowVM.ID changed
    				break;
    			default:
    				break;
    		}
    	}
    }
