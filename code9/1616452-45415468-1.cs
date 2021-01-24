    public class YourRepostiory : BaseRepository 
    {
        public void YourMethod()
        {
            var connectionString = base.ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = sqlstring;
                    loadContextId = (int)command.ExecuteScalar();
                }
            }
        }
    }
