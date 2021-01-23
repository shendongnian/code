    [ImplementPropertyChanged]
    public class WiFiAccessPoint: ViewModelBase
    {
        string _SSID = default(string);
        public string SSID { get { return _SSID; } set { Set(ref _SSID, value); } }
    }
