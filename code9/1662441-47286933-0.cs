    public class Scanner : INotifyPropertyChanged
    {
      private string _Name, _OS;
      public event PropertyChangedEventHandler PropertyChanged;
      public string Name
      {
        get
        {
          return _Name;
        }
        set
        {
          if (value != _Name)
          {
            _Name = value;
            NotifyPropertyChanged("Name");
          }
        }
      }
      public string OS
      {
        get
        {
          return _OS;
        }
        set
        {
          if (value != _OS)
          {
            _OS = value;
            NotifyPropertyChanged("OS");
          }
        }
      }
      public void GetInfo()
      {
        _Name = string.Empty;
        _OS = string.Empty;
        new Thread(() => this.Name = GetName()).Start();
        new Thread(() => this.OS = GetOS()).Start();
      }
      private void NotifyPropertyChanged(string pName)
      {
        if (PropertyChanged != null)
        {
          PropertyChanged(this, new PropertyChangedEventArgs(pName));
        }
      }
      private string GetName() 
      { 
        return "long name operation here"; 
      }
      private string GetOS()
      {
        return "long OS operation here";
      }
    }
