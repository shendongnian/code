    public class games : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _player;
        public int player
        {
            get { return _player; }
            set
            {
                _player = value;
                if (_player > 2)
                {
                    // Fire the Event that it is time to update
                    PropertyChanged(this, new PropertyChangedEventArgs("player"));
                }                
            }
        }          
    }
