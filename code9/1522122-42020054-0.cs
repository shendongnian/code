    public FieldValues(string newName)
    {
        type = FieldType.String;
        name = newName;
        dictionary = new Dictionary<int, string>();
    }
