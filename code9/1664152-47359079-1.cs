    private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgw(propertyName));
                Console.WriteLine("NotifyPropertyChanged Fired.");
    }
