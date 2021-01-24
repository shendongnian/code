    //Assuming the base class looks like
	public class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
    public class BlockFieldViewModel : ViewModelBase
    {
       //...
    
        public int FieldNumber 
        { 
            get
            {
                return _fieldNumber;
            }
            set
            {
                if(_fieldNumber.Equals(value))
                    return;
            
                OnPropertyChanged();
            }
        }
        //...
    }
