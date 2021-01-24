    public string GetRowValue(int row)
    {
        string result;
        if(!dictionary.TryGetValue(row, out result))
            result = "";
        return result;
    }
