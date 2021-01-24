    public static void DeleteList(List<int> idToDelete)
    {
        using (IDbConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            foreach (int id in idToDelete)
            {
                conn.Execute(@"DELETE FROM [User] WHERE Id IN @Id", new {Id = id});
            }
        }
    }
