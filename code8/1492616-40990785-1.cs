    public partial MainPage : Page, INotifyPropertyChanged
    {
        // your code...
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));            
        }
    }
