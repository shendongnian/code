    public bool IsValid1 
        {
            get => _isvalid1;
            set
            {
                _isvalid1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsValid1)));
                ((Command)SendCommand).ChangeCanExecute();
            }
        }
