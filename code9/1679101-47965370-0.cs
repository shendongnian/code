        public void ExecuteSP()
        {
            SqlConnection connection = new SqlConnection("your connectionstring");
            var parameters = new DynamicParameters(new { SequenceName = "SequenceName", UserName = "userName" }); // replace with your actaul params
            connection.Execute("dbo.YourStoredProcedureName", parameters, commandType: CommandType.StoredProcedure);
        }
