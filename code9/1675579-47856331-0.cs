    Public Void UpdateUI()
     {
         //Here update your label, button or any string related object.
         //Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate { }));    
         Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate { }));
     }
