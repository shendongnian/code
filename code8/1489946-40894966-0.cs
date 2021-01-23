    public static void UpdateFromItem(string tableName, object updatevalues, object selectorvalue)
      {
        string updateStr=new String();
        string whereStr=new String();
    
        foreach (PropertyInfo prop in updatevalues.GetType().GetProperties())
        {
        	if (prop.GetValue(parms, null) != null)
        	  updateStr.AppendFormat(" %s=%s",prop.Name, prop.GetValue(parms, null));
        }
    
        foreach (PropertyInfo prop in selectorvalues.GetType().GetProperties())
        {
        	if (prop.GetValue(parms, null) != null)
        	  updateStr.AppendFormat(" %s=%s",prop.Name, prop.GetValue(parms, null));
        }
    
    
      	string sqlStmt=string.Format(@"UPDATE %s SET %s WHERE %s",tableName, updateStr,wherreStr);
    
        Drapper.Execute(sqlStmt);
      }
