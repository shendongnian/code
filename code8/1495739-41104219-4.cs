    using (var db = new DbC())
    {
        var result = db.Database.SqlQuery<MyCustomReturnType>("dbo.PostsRetrieverProc @param1", new SqlParameter("param1", "Blog2"));
        foreach (var item in result)
        {
            Console.WriteLine(item.PostText);
        }
    }
