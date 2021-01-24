    class MyContextFactory
    {
        MyContext CreateContextForDatabase(string dbName) 
        {
            var connString = "...";     // based on dbName
            return new new MyContext(connString);
        }
    }
