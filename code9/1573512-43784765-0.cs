    DataTable ServiceClonRegister = doc.getAllDataRegs(1, 999999999, "b.RegisterId=8 AND b.ACTIVE=1");
    ServiceClonRegister.Columns.Add("NameAndCode");
    foreach (DataRow row in ServiceClonRegister.Rows)
    {
    	row["NameAndCode"] = row["Name"].ToString() + row["CODE"].ToString();
    }
    iServiceClon.DataSource = ServiceClonRegister;
    iServiceClon.DataTextField = "NameAndCode";
    iServiceClon.DataValueField = "ROWID";
    //rest of your code
