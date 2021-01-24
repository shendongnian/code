    public IHttpActionResult GetTest()
    {
    
        string sql = $"SELECT 'Ahmad' AS N'Name',\n" +
            "1 AS N'Code',\n" +
            "0914 AS N'Phone' FOR JSON PATH\n" +
            "SELECT 'Alizadeh' AS N'NameFamily',\n" +
            "2 AS N'Code',\n" +
            "0915 AS N'Phone' FOR JSON PATH\n" +
            " \n" +
            " SELECT 'Seven' AS N'BookName',\n" +
            "3 AS N'Qty',\n" +
            "0916 AS N'IBS' FOR JSON PATH";
        var info = Connections.SaleBranch.SqlConn.QueryMultiple(sql);
        var lstResult = new List<dynamic>();
        var isNext = false;
        do{
            var first2 = info.Read<dynamic>().Single();
            lstResult.Add(first2);
            isNext=info.IsConsumed;
        }
        while (!isNext);
                
        return Ok(lstResult);
    }
