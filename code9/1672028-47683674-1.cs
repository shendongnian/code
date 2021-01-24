    public static class TableAdapterExtensions
    {
      public static void FillWith(this ITableAdapter adapter, IDataTable dataTable)
      {
        try
        {
          adapter.Fill(dataTable);
        }
        catch(SystemException sex)
        {
          GenericExcHandler(sex, DataTable.TableName);
        }
      }
    }
