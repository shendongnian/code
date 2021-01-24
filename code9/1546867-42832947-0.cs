    public class Person : INotifyPropertyChanged
    {
    	private string _firstName;
    	public string FirstName
    	{
    		get { return _firstName; }
    		set
    		{
    			if (value == _firstName) return;
    			_firstName = value;
    			OnPropertyChanged();
    		}
    	}
    
    	private string _lastName;
    	public string LastName
    	{
    		get { return _lastName; }
    		set
    		{
    			if (value == _lastName) return;
    			_lastName = value;
    			OnPropertyChanged();
    		}
    	}
    
    	public override string ToString() => $"{FirstName} {LastName}";
    
    	public event PropertyChangedEventHandler PropertyChanged;
    	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    	{
    		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    	}
    }
