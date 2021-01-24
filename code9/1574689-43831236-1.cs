    string data1 = "";
    if(string.IsNullOrWhiteSpace(textbox1.Text))
    {
        data1 = null;
    }
    else
    {
        data1 = textbox1.Text + "%";
    }
    
    SqlLiteCommand cmd = new SqlLiteCommand();
    cmd.CommandText = qry;
    SqlLiteParameter parData1 = new SqlLiteParameter("@data1", data1);
    cmd.Parameters.Add(parData1);
