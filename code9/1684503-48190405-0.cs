    var button = (Button)ControlDictionary[processDataProperty.Key];
    var cmd = new RelayCommand(() =>
    {
         try
         {
             Process.Start(processDataProperty.Value.ToString());
         }
         catch (Exception ex)
         {
              Log.Debug(ex);
         }
    });
    button.Command = cmd;
