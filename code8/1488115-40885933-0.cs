    public DataTable ToDataTable<T>(List<T> items)
    {
       DataTable ResultsTable = new DataTable(typeof(T).Name);
       //Gets all the properties
       PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
       foreach (PropertyInfo prop in Props)
       {
          //Sets column names as Property names
          ResultsTable.Columns.Add(prop.Name);
       }
       foreach (T item in items)
       {
          var values = new object[Props.Length];
          for (int i = 0; i < Props.Length; i++)
          {
             //Inserts property values to datatable rows
             values[i] = Props[i].GetValue(item, null);
          }
          ResultsTable.Rows.Add(values);
       }
       return ResultsTable;
    }
