    public string ListItems
    {
        get { return listItems; }
        set
        {
             listItems= value;
             // Call OnPropertyChanged whenever the property is updated
             OnPropertyChanged("ListItems");
         }
    }
      // Create the OnPropertyChanged method to raise the event
      protected void OnPropertyChanged(string name)
      {
          PropertyChangedEventHandler handler = PropertyChanged;
          if (handler != null)
          {
              handler(this, new PropertyChangedEventArgs(name));
          }
      }
