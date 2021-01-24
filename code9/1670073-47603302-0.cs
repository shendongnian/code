    class Meta 
    {
        private static bool hasUpdate = false;
        public static event PropertyChangedEventHandler StaticPropertyChanged;
        public static bool GetHasUpdate()
        {
            return hasUpdate;
        }
        public static void SetHasUpdate(bool value)
        { 
            hasUpdate = value;
            StaticNotifyPropertyChanged();
        }
        private static void StaticNotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
    }
