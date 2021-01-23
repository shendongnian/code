    public void SaveBook()
    {
        // This line defines a local variable with the same name of the global one
        // It hides the global, if you expect your client to provide the connection
        // then remove the line
        SqlConnection _sqlcon = new SqlConnection();
        ....
 
