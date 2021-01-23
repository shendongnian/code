    DataBaseConnection obtainData;
    private void Login_Load(object sender, EventArgs e)
    {
        //Instantiating DB Obj
        obtainData = new DataBaseConnection();
        //Filling dataset
        obtainData.passSqlCmdandFillDs = "select * from [tblLogin]";
    }
    private void txtDisplay_TextChanged(object sender, EventArgs e)
    {
        if (obtainData != null)
        {
            // Use obtainData here
        }
    }
