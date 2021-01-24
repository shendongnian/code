    List<EMP> list= db.EMPs.ToList();
    DataTable dt = new DataTable();       
    PropertyInfo[] Props = typeof(EMP).GetProperties(BindingFlags.Public | BindingFlags.Instance);
    foreach (PropertyInfo prop in Props)
    {
        //Setting column names as Property names
        dt.Columns.Add(prop.Name);
    }
    foreach (EMP e in list)
    {
        var values = new object[Props.Length];
        for (int i = 0; i < Props.Length; i++)
        {
            //inserting property values to datatable rows
            values[i] = Props[i].GetValue(e, null);
        }
        dt.Rows.Add(values);
    }
