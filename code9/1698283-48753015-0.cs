    public string GetDataFolder()
    {
        #if NETFX_CORE
            return Windows.Storage.ApplicationData.Current.LocalFolder.Path;
        #else
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
        #endif
    }
