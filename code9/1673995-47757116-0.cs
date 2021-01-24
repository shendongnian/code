    public static class DbUtility
    {
        public static OleDbConnection eConnection(string srcString)
        {
            conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + srcString + "; Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
            connection = new OleDbConnection(conString);
            connection.Open();
            return connection;
        } 
        .... other static utilities
    }
