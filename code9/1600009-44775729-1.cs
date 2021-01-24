    public class Ruqya : INotifyPropertyChanged
    {
       private int _numOfTimes;
       public int NumOfTimes
       {
           get
           {
               return _numOfTimes;
           }
           set
           {
               this._numOfTimes = value;
               this.OnPropertyChanged();
           }
       }
       public string RuqyaName { get; set; }
       public int index { get; set; }
       public event PropertyChangedEventHandler PropertyChanged =delegate { };
      
       public void OnPropertyChanged([CallerMemberName] string propertyName = null)
       {
           // Raise the PropertyChanged event, passing the name of the property whose value has changed.
           this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
       }
    }
