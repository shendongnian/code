    private void GetValues()
    {
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataTable dt = new DataTable();
        da.Fill(dt, "Your recordset");//not in  quotes
        Int32 index = 0; //index of the column you need
        foreach (DataRow row in dt.Rows)
            {
                String result = row[index].ToString();
                Debug.Print(result);
            }
    }
