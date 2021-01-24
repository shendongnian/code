    public class YourClass : window, INotifyPropertyChanged
    
        public string A.B.C.D.E {Get ; set ;}
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
              handler(this, new PropertyChangedEventArgs(name));
            }
        }
