    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    public class MyModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isButtonVisible;
        public bool vButton
        {
            get { return _isButtonVisible; }
            set
            {
                if (value == _isButtonVisible)
                    return;
                _isButtonVisible = value;
                OnPropertyChanged();
            }
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
