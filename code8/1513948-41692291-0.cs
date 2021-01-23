        public DataTable ProdTypeSelectAll(string cultureCode)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pk_ProdType_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("ProdType");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.Parameters.Add(new SqlParameter("@CultureName", cultureCode));
            _mainConnection.Open();
            adapter.Fill(toReturn);
            return toReturn;
    }
