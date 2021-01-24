    private Dictionary<string, string> _Dic;
    public Dictionary<string, string> Dic
    {
        get
        {
            if (_Dic == null)
            {
                _Dic = new Dictionary<string, string>();
    
                _Dic.Add("A", "X");
                _Dic.Add("B", "Y");
                _Dic.Add("C", "Z");
                // add more key-pair values in the future
                return _Dic;
            }
            else
            {
                return _Dic;
            }
        }
    
        set
        {
            // important: here you can get your valus from external source!
            _Dic = value;
        }
    }
    
    string MyMethod(string filter)
    {
        StringBuilder sbFilter = new StringBuilder(filter);
        foreach (KeyValuePair<string, string> itm in Dic)
        {
            if (filter.Contains(itm.Key))
            {
                sbFilter.Append(Dic[itm.Key]);
            }
        }
    
        return sbFilter.ToString();
    }
