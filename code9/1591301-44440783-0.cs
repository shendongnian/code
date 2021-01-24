    if (dateType == "DateFiled")
    {
      SqlDataSource1.SelectParameters.Add(new Parameter("DateField1", TypeCode.String, DateField1));
      SqlDataSource1.SelectParameters.Add(new Parameter("DateField2", TypeCode.String, DateField2));
        
      SqlDataSource1.SelectCommand = "SELECT * FROM tbl_dateCorrection WHERE DateFiled BETWEEN @DateField1 AND @DateField2";
       SqlDataSource1.DataBind();
       GridView1.DataBind();
    }
    else {
       //some other Date
      SqlDataSource1.SelectParameters.Add(new Parameter("DateField1", TypeCode.String, DateField1));
      SqlDataSource1.SelectParameters.Add(new Parameter("DateField2", TypeCode.String, DateField2));
        
      SqlDataSource1.SelectCommand = "SELECT * FROM tbl_dateCorrection WHERE SomeOtherDate BETWEEN @DateField1 AND @DateField2";
       SqlDataSource1.DataBind();
       GridView1.DataBind();
    }
