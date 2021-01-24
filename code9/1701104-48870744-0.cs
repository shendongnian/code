    if(parameters.Contains("AvailableVals"))
    {                     
                    parameters.Item("AvailableVals").SqlDbType = SqlDbType.Structured;
                    parameters.Item("AvailableVals").Direction = ParameterDirection.Input;
                    parameters.Item("AvailableVals").TypeName = "dbo.udtGenExpression";
                    parameters.Item("AvailableVals").Value = inputValues.GetIdTable();
    }     
      
