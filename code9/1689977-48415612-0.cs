    class DAL
    {
        private readonly string _connectionString;
        public DAL(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DataTable SearchAll(string searchText)
        {
            var sql = "SELECT * FROM tblCommunication "+
                      "WHERE LetterType = @searchText "+
                      "OR LetterNumber = @searchText  "+
                      "OR LetterAmount = @searchText  "+
                      "OR LetterFrom  = @searchText  "+
                      "OR LetterTo  = @searchText  "+
                      "OR ReceivedBy  = @searchText  "+
                      "OR Requisition  = @searchText  "+
                      "OR LetterSubject  = @searchText  "+
                      "OR LetterContent  = @searchText  "+
                      "OR LetterRemarks  = @searchText";
            var parameter = new SqlParameter("@searchText", SqlDbType.VarChar);
            parameter.Value = searchText;
            return GetDataTable(sql, CommandType.Text, parameter);
        }
        public DataTable SearchIncomingCommunications(string caterogy, string searchText) 
        { 
            // implementation same as the example above
            throw new NotImplementedException();
        }
        public DataTable SearchInsideCommunications(string caterogy, string searchText)
        {
            // implementation same as the example above
            throw new NotImplementedException();
        }
        // add other methods as well
     private DataTable GetDataTable(string sql, CommandType commandType, params SqlParameter[] parameters)
        {
            var dt = new DataTable();
            using (var con = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = commandType;
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
