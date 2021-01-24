    public class className: INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
    
        protected void OnPropertyChanged(string propertyName)
        {
        	if (PropertyChanged != null)
        	{
        		PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        	}
        }
    
       //then create a string variable in your .xaml.cs file like   
    
        private string _logText;
    
        public string LogText
        {
             get{ return _logText;}
             set { _logText = value; OnPropertyChanged("LogText"); }
        }
    }
