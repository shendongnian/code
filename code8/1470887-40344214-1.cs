        public void InsertQuestion(IEnumerable<string> area_list)
        {
            var connect = new OracleConnection("YOUR CONNECTION STRING");
        
            var command = new OracleCommand("BEGIN Testpackage.Testprocedure(:Areas); END;", connect);
    
            connect.Open();
    
            var arry = command.Parameters.Add("Areas", OracleDbType.Varchar2);
        
            arry.Direction = ParameterDirection.Input;
            arry.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
            arry.Value = area_list.ToArray();
            arry.Size = area_list.Count();
            arry.ArrayBindSize = area_list.Select(_ => _.Length).ToArray();
            arry.ArrayBindStatus = Enumerable.Repeat(OracleParameterStatus.Success, area_list.Count()).ToArray();
    
            command.ExecuteNonQuery();
        
            connect.Close();
        }
