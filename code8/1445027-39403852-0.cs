    protected void gvCodes_RowUpdating(object sender, GridViewUpdateEventArgs e)
     {
        GridViewRow row = (GridViewRow)gvCodes.Rows[e.RowIndex];
        TextBox textID = (TextBox)row.Cells[0].Controls[0];
        TextBox textDate = (TextBox)row.Cells[0].Controls[0];
        TextBox textManagerName = (TextBox)row.Cells[0].Controls[0];
        
        CodesDataSource.ConnectionString = ba.connection;
        CodesDataSource.SelectCommand = "SELECT * FROM Codes WHERE ProjProjectID = '" + projProjectID + "'";
        CodesDataSource.UpdateCommand = "UPDATE Codes SET Manager_Name = @Manager_Name, Created_Date = GETDATE() WHERE Id = @Id AND ProjProjectID = '" + projProjectID + "'";
        CodesDataSource.UpdateParameters.Add("Manager_Name", TypeCode.String, textManagerName.Text);
        CodesDataSource.UpdateParameters.Add("Created_Date", TypeCode.String, textDate.Text);
        CodesDataSource.UpdateParameters.Add("Id", TypeCode.String, textID.Text);
     }
