    public static class SqlExtensions
    {
        public static DataTable ExecuteDataTable(this SqlCommand command)
        {
            DataTable table = new DataTable();
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
            {
                dataAdapter.Fill(table);
            }
            return table;
        }
    }
