    string excelConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["xlsx"].ConnectionString + fileLocation;
    //connection String for xls file format.
    if (fileExtension == ".xls")
    {
        excelConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["xlsx"].ConnectionString + fileLocation;
    }
    //connection String for xlsx file format.
    else if (fileExtension == ".xlsx")
    {
        excelConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["xlsx"].ConnectionString + fileLocation;                        
    }
    //Create Connection to Excel work book
    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
    excelConnection.Open();
