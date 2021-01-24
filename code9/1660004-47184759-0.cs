    [Preserve(AllMembers = true)]
    public class LinkerPleaseInclude
    {
        public void Include(SQLiteAsyncConnection connection)
        {
            connection.CreateTableAsync();
        }
    }
