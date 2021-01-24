    public void Update(T model)
    {
        if (!Exist(model))
        {
            throw new Exception("Object Not Found");
        }
        DataRow tmp = GetRow(model);
        _dataAdapter.Update(new []{ tmp });
    }
    private DataRow GetRow(T model)
    {
        DataRow row = Convert(model);
        var schem = Schema;
        string[] keys = new string[schem.PrimaryKey.Length];
        for (var i = 0; i < schem.PrimaryKey.Length; i++)
        {
            DataColumn column = schem.PrimaryKey[i];
            keys[i] = row[column.ColumnName].ToString();
        }
        DataRow dr = Convert(Select(keys));
        dr.Table.Rows.Add(dr);
        dr.AcceptChanges();
        for (var i = 0; i < row.ItemArray.Length; i++)
        {
            if (!schem.Columns[i].AutoIncrement)
            {
                dr[i] = row.ItemArray[i];
            }
        }
        return dr;
     }
