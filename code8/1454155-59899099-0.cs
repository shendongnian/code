    //Convert it to a data table, then the Automatic will work.
    DataGridView.DataSource = ConvertToDataTable(MyList).DefaultView;
    
    public DataTable ConvertToDataTable(IBindingList list)
    {
       DataTable dt = new DataTable();
    
       if (list.Count > 0)
       {
          Type typ = list[0].GetType();
    
          PropertyInfo[] arrProps = typ.GetProperties();
    
          foreach (PropertyInfo pi in arrProps)
          {
    
             Type colType = pi.PropertyType;
             if (colType.IsGenericType)
             {
                colType = colType.GetGenericArguments()[0];
             }
    
             dt.Columns.Add(pi.Name, colType);
          }
    
          foreach (object obj in list)
          {
             DataRow dr = dt.NewRow();
    
             foreach (PropertyInfo pi in arrProps)
             {
                if (pi.GetValue(obj, null) == null)
                   dr[pi.Name] = DBNull.Value;
                else
                   dr[pi.Name] = pi.GetValue(obj, null);
             }
    
             dt.Rows.Add(dr);
          }
       }
       return dt;
    }
