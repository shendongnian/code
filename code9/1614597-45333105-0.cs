    public void GetEmployeeDataUsingProcedure()
    {
        object[] parameters = new SqlParameter[4];
        List<EmployeeResultSet> lstEmployees = new List<EmployeeResultSet>();
        try
        {
            using (var db = new DevelopmentTestDatabaseContext())
            {
                parameters[0] = new SqlParameter("@departmentname", "IT");
                parameters[1] = new SqlParameter("@sortCol", "ID");
                parameters[2] = new SqlParameter("@sortdir", "asc");
                parameters[3] = new SqlParameter("@searchString", "ope");
                var results = db.Database.SqlQuery<EmployeeResultSet>("proc_getEmployees @departmentname, @sortCol, @sortdir, @searchString", parameters);
                db.Database.Log = query => System.Diagnostics.Debug.Write(query);
                lstEmployees = results.ToList();
            }
        }
        catch (Exception ex)
        {
            //log it or something
        }
    }
