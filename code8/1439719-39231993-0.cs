    sda.Fill(dbdataset);
    DataTable dt = dbdataset.Tables[0];
    DataRow row = dt.NewRow();
    row.ItemArray = new object[] {"--OTHERS--"};
    dt.Rows.InsertAt(row, 0);
    cbPart.DataSource = dt;
    cbPart.DataSource = dbdataset.Tables[0];    //Plus adding this line
    cbPart.DisplayMember = "item_type";         //And this, plus "item_type" is the name of the column
