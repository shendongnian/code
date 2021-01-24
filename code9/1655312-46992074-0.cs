    private RelayCommand<object> _YourCommand;
    public RelayCommand<object> YourCommand
    {
        get
        {
    
            return _YourCommand
                ?? (_YourCommand = new RelayCommand<object>(
                                      p =>
                                      {
                                          var values = (object[]) p;
                                          int item1 = int.Parse(values[0].ToString());
                                          string item2 = values[1].ToString();
                                          double item3 = double.Parse(values[2].ToString());
                                          
                                      }));
        }
    }
