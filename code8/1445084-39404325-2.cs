    private DataTable SearchData (string name)
    {
        DataTabel dt = new DataTable();
        string connStr; // connection string
        string command = "SELECT ID, LastName, FirstName, MiddleName, Gender, BirthDate,"+
                         "CivilStatus, Citizenship, MobileNo, Landline, PermanentAddress,"+
                         "Address FROM Residents WHERE FirstName LIKE '" + name + 
                         "' OR LastName LIKE '" + name + "'";
        dt = SQLQuery.SQLGetData(connStr, command).Tables[0];
        return dt;
    }
