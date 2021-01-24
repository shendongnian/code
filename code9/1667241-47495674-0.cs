    public class Game : INotifyPropertyChanged
    {
        private bool _isPlaying;
        
        public string IsPlaying
        {
            get { return _isPlaying; }
            set {
                _isPlaying = value;
                this.NotifyPropertyChangedBool();    
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChangedBool()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new 
                               PropertyChangedEventArgs("IsPlaying"));
            }
        }
