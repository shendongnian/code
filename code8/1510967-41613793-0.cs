    protected void DropDownList_Reload()
        {
            MyDataSource.ConnectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
            MyDataSource.SelectCommand = "SELECT * FROM [tblMyTable] WHERE [IsDeleted] <> 1";
    
            cbxDropDownList.DataSourceID = "MyDataSource";
            cbxDropDownList.DataTextField = "MyHeader";
            cbxDropDownList.DataValueField = "MyHeader";
        }
