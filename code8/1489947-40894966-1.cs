      public static void UpdateStudent(Student inobj)
      {
        string updateStr=new String();
        string whereStr=string.Format(@"Id=%s",inobj.Id);
    
        foreach (PropertyInfo prop in inobj.GetType().GetProperties())
        {
        	if ((prop.GetValue(parms, null) != null) && (prop.Name != 'Id'))
        	  updateStr.AppendFormat(" %s=%s",prop.Name, prop.GetValue(parms, null));
        }
       
      	string sqlStmt=string.Format(@"UPDATE %s SET %s WHERE %s",tableName, updateStr,wherreStr);
    
        Drapper.Execute(sqlStmt);
      }
  
