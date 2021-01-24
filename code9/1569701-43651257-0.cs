    var parameter = new Parameter("test")
    {
      DefaultValue = String.IsNullOrEmpty(TB_Test.Text.ToString()) 
         ? "" : TB_Test.Text.ToString()),
    
      ConvertEmptyStringToNull = false
    };
    SqlDataSource1.UpdateParameters.Add(parameter);
