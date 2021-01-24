    // by implementing the INotifyPropertyChanged, changes to properties
    // will update the listbox on-the-fly
    public class MyObject : INotifyPropertyChanged
    {
         private string _title;
         
         // a property.
         public string Title
         {
             get { return _title;}
             set
             {
                 if(_title!= value)
                 {
                     _title = value;
                     PropertyChanged?.Invoke(this, new PropertyChangedEventArgs( nameof(Title)));
                 }
             }
         }
         public event PropertyChangedEventHandler PropertyChanged;
    }
