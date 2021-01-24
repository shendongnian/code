    public class Ruqya : INotifyPropertyChanged
    {
       private int _numOfTimes;
       public int NumOfTimes
       {
           get
           { return _numOfTimes; }
           set
           {
               this.Set(ref _numOfTimes, value);
           }
       }
       public string RuqyaName { get; set; }
       public int index { get; set; }
       public event PropertyChangedEventHandler PropertyChanged;
       public void RaisePropertyChanged([CallerMemberName]string propertyName = null)
       {
           if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
               return;
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
       }
       protected virtual bool Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
       {
           if (object.Equals(storage, value))
               return false;
           storage = value;
           RaisePropertyChanged(propertyName);
           return true;
       }
    }
