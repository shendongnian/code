    public abstract class ViewModelBase
    {
        protected static SilentDictionary<string, Action> _permissions;
    
        public static SilentDictionary<string, Action> Permissions
        {
            get { return _permissions; }
            set
            {
                _permissions = value;
                NotifyPropertyChanged();
            }
        }  
    
        public static event EventHandler PermissionsChanged;
    
        protected static void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            EventHandler temp = Volatile.Read(ref PermissionsChanged);
            PermissionsChanged?.Invoke(null, new EventArgs());
        }
    
        // other code
    }
