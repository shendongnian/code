    OleDbCommand oconn = new OleDbCommand("Select * From [Sheet1$] WHERE Date = @date");
    oconn.Connection = connection;
    try
    {
        oconn.Parameters.AddWithValue("@date", DateTime.Now.ToString("MM/dd/yyyy"));
        connection.Open();
        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
        DataTable data = new DataTable();
        sda.Fill(data);
        connection.Close();
    }
    catch (Exception)
    {
    }
