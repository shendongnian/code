    interface IDatabase {
      object ExecuteDB(string);
    }
    class DBSql_Class : IDatabase {
      public object ExecuteDB(string query) {
        ...
      }
    }
    static class MyModuleClass {
      public static IDatabase TypeDB() {
        switch(...) {
          ...
          return new DBSql_Class();
          ...
        }
      }        
    }
