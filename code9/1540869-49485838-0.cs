    public static event PropertyChangedEventHandler StaticPropertyChanged;
    
    private static void NotifyStaticPropertyChanged([CallerMemberName] string name = null)
    {
        StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(name));
    }
