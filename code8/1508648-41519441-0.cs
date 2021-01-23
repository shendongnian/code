    public static event PropertyChangedEventHandler StaticPropertyChanged;
    public static void NotifyStaticPropertyChanged([CallerMemberName] string name = null)
    {
        StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(name));
    }
