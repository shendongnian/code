    dynamic returnedData = null;
    using (IDbConnection db = new SqlConnection(SqlDataAccess.LoadConnectionString("TestData")))
    {
        returnedData = db.Query<dynamic>(
            "StoredProcedureName"
        ,   new {
                ClientId = myClientId
            ,   CompanyId = myCompanyId
            }
        ,   commandType: CommandType.StoredProcedure
        ).SingleOrDefault();
    }
    Console.WriteLine(
        "ClientId={0}, CompanyId={1}"
    ,   returnedData?.ClientId
    ,   returnedData?.CompanyId
    );
