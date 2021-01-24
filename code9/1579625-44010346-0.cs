    DataTable usersTable = new DataTable();
    usersTable.Columns.Add("FirstName");
    usersTable.Columns.Add("LastName");
    usersTable.Columns.Add("Email");
    DataRow userRow = usersTable.NewRow();
    userRow["FirstName"] = "Elmer";
    userRow["LastName"] = "Example";
    userRow["Email"] = "elmer@example.com";
