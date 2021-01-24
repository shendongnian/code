    public class MySqlException : DbException
    {
        public string Database { get; set; }
    } 
    SqlConnection conn;
    try
    {
        
    }
    catch (SqlException ex)
    {
        throw new MySqlException() {Database = conn.Database};
    }
