    public class TabItemData : INotifyPropertyChanged
    {
      private string name;
      public string Name
      {
        get { return this.name; }
        set 
        {
            if (value != this.name)
            {
                this.name= value;
                NotifyPropertyChanged("Name");
            }
        }
      }
      public event PropertyChangedEventHandler PropertyChanged;
      private void NotifyPropertyChanged(string propertyName)
      {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
      }
    }
