    public class SystemCheckingNormal : INotifyPropertyChanged
    {
        private string hostname ;
        private string iPAddress ;
        private string online ;
        private string lastRestarted ;
        private string oS ;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        Public string Hostname
        {
           get{return hostname;}
           set
           {
              if(hostname != value)
                {
                  hostname = value;
                  OnPropertyChanged("Hostname");
                }
           }
        }
    }
