    public void DoStuffWithExcel(string srcString)
    {
        conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + srcString + "; Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
        using(var connection = new OleDbConnection(conString))
        {
            connection.Open();
            // do your stuff here...
        }
    }
