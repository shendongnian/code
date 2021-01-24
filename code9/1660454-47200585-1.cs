    private static readonly object _selectedFacilitiesLocker=new object();
    private static Dictionary<string, SportsFacility> _selectedFacilities = new Dictionary<string, SportsFacility>();
    private static bool TryGetSelectedFacility(string key, out SportsFacility facility)
    {
        // Since you are in a web environment and are using statics, you must lock this index whenever you use it
        lock(_selectedFacilitiesLocker)
        {
            return _selectedFacilities.TryGetValue(key, out facility);
        }
    }
    private static void UpdateSelectedFacility(string key, SportsFacility facility)
    {
        // Since you are in a web environment and are using statics, you must lock this index whenever you use it
        lock(_selectedFacilitiesLocker)
        {
            _selectedFacilities[key] = facility;
        }
    }
    public static SportsFacility SelectedFacility
    {
        get
        {
            SportsFacility facility;
            if(!TryGetSelectedFacility(HttpContext.Current.Session.SessionID, out facility))
                return null;
            else 
                return facility;
        }
        set
        {
            UpdateSelectedFacility(HttpContext.Current.Session.SessionID, value);
        }
    }
