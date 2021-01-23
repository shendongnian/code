    DataTable mainTable = new DataTable();
    for (int i = 0; i <= selectedrows.Rows.Count - 1; i++)
    {
        string date1 = selectedrows.Rows[i]["Date"].ToString();
        System.DateTime dateexcel = System.DateTime.ParseExact(date1, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        //check select rows exists or not in DB
        SqlCommand cmd = new SqlCommand("select * from UploadTable where Date='" + dateexcel+"'", con);
        da = new SqlDataAdapter(cmd);
        var dBdt = new DataTable();
        da.Fill(dBdt); 
        mainTable.Merge(dBdt);
    }  
