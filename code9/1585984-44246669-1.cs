    public async Task SetPath(string value)
    {
         if (_path != value) {
             _path = value;
             OnPropertyChanged(nameof(Path));
             await Task.Run(()=> ...);
    }
