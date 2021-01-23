    using System.Runtime.CompilerServices;
    ...
    public static event PropertyChangedEventHandler StaticPropertyChanged;
    private static void NotifyStaticPropertyChanged(
        [CallerMemberName] string propertyName = null)
    {
        StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
    }
