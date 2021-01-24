    public static void DeleteList(List<int> idToDelete)
    {
        using (IDbConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            conn.Execute(@"DELETE FROM [User] WHERE Id = @Id",
                idToDelete.Select(x => new { Id = x }).ToArray());
        }
    }
