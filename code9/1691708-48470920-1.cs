      public partial class MainWindow : Window
      {
        private object emergencyLock = new object();
        private string _status;
        public string status
        {
          get
          {
            //make sure if an emergency is happening we get the best possible string.
            lock (emergencyLock)
            {
              return _status;
            }
          }
          set
          {
            //we could also lock here instead of in GetEmergencyString()..which would fix the get+set=atomic issue
            _status = value;
          }
        }
        private string GetEmergencyString()
        {
          //this function understands an emergency is happening
          lock (emergencyLock)
          {
            //Maybe I'm fetching this string from a database, or building it by hand
            //It takes a while...We'll simulate this here
            Thread.Sleep(1000);
            return "Oh crap, emergency!";
          }
        }
        private void Normal_Button_Click(object sender, RoutedEventArgs e)
        {
          status = "Nothing much going on.";
        }
    
        private void Emergency_Button_Click(object sender, RoutedEventArgs e)
        {
          //GetEmergencyString() is evaluated first..finally returns a string, 
          //and THEN the assignment occurs as a single operation
          status = GetEmergencyString();
        }
      }
