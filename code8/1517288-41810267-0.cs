    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public class Car: INotifyPropertyChanged
    {
    	#region Property Changed
    	public event PropertyChangedEventHandler PropertyChanged;
    	protected void OnPropertyChanged(string propertyName)
    	{
    		if (PropertyChanged != null)
    		{
    			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
    	#endregion
    	
    	private string _modelNum;
    		
    	public string ModelNum 
    	{
    		get{ return _modelNum; }
    		set 
    		{ 
    			_modelNum = value; 
    			//this will raise the notification
    			OnPropertyChanged("ModelNum"); 
    		}
    	}
    }
