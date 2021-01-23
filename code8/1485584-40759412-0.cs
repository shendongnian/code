     DataTable table = new DataTable();
    
    foreach (CallData data in p.ValueArray)
    {
        DataRow row = table.NewRow();
        foreach (CallParm parm in data.Parm)
        {
            if (!table.Columns.Contains(parm.Name))
            {
                table.Columns.Add(parm.Name, typeof(string));
            }
            row[parm.Name] = parm.Value;
            //now you add all items in this loop not only last element.
            table.Rows.Add(row);
        }
        
    }
