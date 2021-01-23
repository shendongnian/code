    public void InsertQuestion(List<string> area_list)
        {
            var input_array = area_list.Select(s => (object)s).ToArray();
            command = new OracleCommand();
            command.Connection = connect;           
            connect.Open();
    
            var arry = command.Parameters.Add("area_array",OracleDbType.Varchar2);
            arry.Direction = ParameterDirection.Input;
            arry.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
            arry.Value = input_array;            
    
            command.CommandText ="TESTPROCEDURE";
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            connect.Close();
        }
