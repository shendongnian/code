        List<ReportParameter> lstParam = new List<ReportParameter>();
    foreach(var item in lstParam )
    {
    //and then loop through class properties 
    Type type = item.GetType();
    PropertyInfo[] properties = type.GetProperties();
    
    foreach (PropertyInfo property in properties )
    {
        //now here you can play with class properties 
    //like property.Name or property.Value
    //place your check here
    }
    }
