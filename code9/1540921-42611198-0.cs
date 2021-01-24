    protected override int GetCount(List<int> itemlist)
    {
        sql.Execute(@"TRUNCATE Table table0");
        int count = 0;
        string sql = @"WITH b AS
                        (
                            {0}
                        )
                        INSERT  INTO table0 (ID, Guid)
                        SELECT ID, Guid
                        FROM b";
        
        List<string> sqlsubs = new List<string>();
        foreach (int itemgroup in itemlist)
        {
            sqlsub.Add( string.Format(@"SELECT  table1.ID , table1.Guid
                                        FROM	dbo.tablefunction({0}) table1 LEFT JOIN
                                                dbo.table0 ON table1.ID = table0.ID
                                        WHERE   table0.ID IS NULL", itemgroup));
        }
        
        string sqlunion = string.Join(" UNION ", sqlsub);
        return context.Execute(string.Format(sql, sqlunion));
    }
