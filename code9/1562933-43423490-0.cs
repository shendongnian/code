            var parameters = new Dictionary<string, object>();
            parameters.Add("ID", empId);
           
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.AddDynamicParams(parameters);
