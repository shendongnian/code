    public DataTable CreateTableFromEnum(Type t)
    {
        DataTable dt = new DataTable();
        if (t.IsEnum)
        {
            dt.Columns.Add("key", t);
            dt.Columns.Add("text", typeof(string));
            
            foreach(var v in Enum.GetValues(t))
                dt.Rows.Add(v, v.ToString());
        }
        return dt;
        
    }
