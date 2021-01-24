    namespace POSystem
    {
      public class POProperties : INotifyPropertyChanged
      {
        public POProperties() { }
    
        private static readonly POProperties instance = new POProperties();
        public static POProperties Instance { get => instance; }
    
        private UserInformation uinfo = new UserInformation();
        public UserInformation GetUserInformation { get => uinfo; }
    
        private Cursor _ltc_cursor;
        public Cursor LTC_Cursor
        {
          get => _ltc_cursor ?? new Cursor(new MemoryStream(Properties.Resources.LTC_Custom_Cursor));
          set => _ltc_cursor = value;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string Name = "")
        { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name)); }
    }
