        ...
        Func<DataRow, bool> whereClause = row => SomeClass.Evaluate(filter.Condition, row);
        ...
    public static class SomeClass
    {
         public static bool Evaluate(string expression, DataRow data)
         {
              ... do some sophisticated stuff ...
              return true /  false;
         }
    }
