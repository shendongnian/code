     public string Name {
       get { return name;}
       set { 
          name = value; OnPropertyChanged("Name");
          IsVisibleName = name != null; IsVisibleEvent = event != null && name != null;
     }
