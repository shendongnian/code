    string data1 = null;
    if(!string.IsNullOrWhiteSpace(textbox1.Text))
    {
        data1 = textbox1.Text + "%";
    }
    
    SqlLiteCommand cmd = new SqlLiteCommand(qry, con);
    SqlLiteParameter parData1 = new SqlLiteParameter("@data1", (object)data1 ?? DBNull.Value);
    cmd.Parameters.Add(parData1);
