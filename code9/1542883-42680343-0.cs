    /// <summary>
    /// A global on property change that runs for any instantiated object of this type.
    /// </summary>
    /// <param name="name"></param>
    static void OnGlobalPropertyChanged(string name)
    {
        GlobalPropertyChanged(
            this,
            new PropertyChangedEventArgs(name)
        );
    }
