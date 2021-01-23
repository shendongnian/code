    public class Model:INotifyPropertyChanged
    {
        public Uri ImageSource{get;set;}
        public double _gridWidth;
        public double GridWidth
        {
            get { return _gridWidth; }
            set {
                _gridWidth = value;
                RaisePropertyChanged();
            }
        }
        public void RaisePropertyChanged([CallerMemberName]string name="")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
