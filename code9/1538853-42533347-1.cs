    public string FieldsPivoted
    {
        get
        {
            return string.Join(", ", Fields.Select(x => x.Value));
        }
    }
