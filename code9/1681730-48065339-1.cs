    private void setInformation(DataTable dt, List<string> text)
    {
        var cache = new Dictionary<string, int>(); //cache column numbers
        foreach(var entry in text) cache[entry] = getColumnNumberByValue(dt, entry);
        for(int i=1; i < dt.Rows.Count; i++)
        {
            foreach(var entry in text)
            {
                var columnIndex = cache[entry];
                if(columnIndex != -1)
                {
                    var valueNeeded = dt.Rows[i][columnIndex].ToString();
                }
            }
        }
    }
    private int getColumnNumberByValue(DataTable dataTable, string text)
    {
        for(int i=0; i < dataTable.Columns.Count; i++)
        {
            if(dataTable.Rows[0][i].ToString() == text) return i;
        }
        return -1;
    }
