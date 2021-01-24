    DataTable TablesList = conn.GetSchema("Tables");
    foreach (DataRow TableRow in TablesList.Rows)
    {
        if (TableRow["TABLE_NAME"].ToString().EndsWith("$") | TableRow["TABLE_NAME"].ToString().EndsWith("$'"))
        {
            // Handle the Excel Sheet
        }
    }
