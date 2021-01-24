    private static IDictionary<int, int> _dict = null;
    public static IDictionary<int, int> CreateDict()
    {
        if(_dict == null)
        {
            _dict = new Dictionary<int, int>();
        }
        return _dict;
    }
