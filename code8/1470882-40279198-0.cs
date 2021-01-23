    public static Int32? CustomConvertToInt32(Object obj)
    {
        string _strData = CustomConvertToStringOrNull(obj);
        Int32? _Nullable = null;
        Int32 _data;
        if (Int32.TryParse(_strData, out _data))
        {
            _Nullable = _data;
        }
        return _Nullable;
    }
     public static string CustomConvertToStringOrNull(Object obj)
        {
            string _Nullable = null;
            if (obj != null)
            {
                if (obj.ToString().Trim() == "" || obj.ToString().Trim().ToLower() == "n/a")
                {
                    _Nullable = null;
                }
                else
                {
                    _Nullable = obj.ToString().Trim();
                }
            }
    
            return _Nullable;
        }
    int? siteNumber = CustomConvertToInt32(someStr);
