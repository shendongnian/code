    public static DataTable ConvertToTable(IEnumerable<Person> people)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Name");
        dt.Columns.Add("Age");
        
        foreach (var person in people)
        {
            var row = dt.NewRow();
            row[0] = person.Name;
            row[1] = person.Age;
            dt.Rows.Add(row);
        }
        
        return dt;
    }
