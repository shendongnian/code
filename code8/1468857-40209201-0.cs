     SqlParameter parameter = new SqlParameter();
     parameter.ParameterName = "@myData";
     parameter.SqlDbType = System.Data.SqlDbType.Structured;
     parameter.TypeName = "dbo.YourCustomTableType";
     parameter.Value = myDataTable;    
