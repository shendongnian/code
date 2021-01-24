    private static bool ComputeCondition(string value) {
      using (DataTable dt = new DataTable()) {
        return (bool)(dt.Compute(value, null));
      }
    }
...
    string condition ="25<10"; 
    if (ComputeCondition(condition)) {
      ...  
    }
    else {
      ...
    }
