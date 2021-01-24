    dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
    dispatcherTimer.Tick += (s,e)=>{
       if( MessageBox.Show("Do you accept the request", "Invitation", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
       {
           Task.Run(()=>CheckForRequests());
       }
    }
    dispatcherTimer.Interval = new TimeSpan(0,0,1);
    dispatcherTimer.Start();
