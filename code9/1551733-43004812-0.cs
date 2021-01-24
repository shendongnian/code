    public Dictionary<string, int> Dictionary
    {
        get
        {
            return (Dictionary<string, int>)GetValue(DictionaryProperty);
        }
        set
        {
            SetValue(DictionaryProperty, value);
        }
    }
