    // think on turning the method into static  
    private void PerformList<T>(List<T> list) {
      // try failed
      if (null == list)
        return;
      // foreach (var item in list) {...} may be a better choice 
      for (int i = 0; i < list.Count; ++i) {
        string str = list[i].ToString();
        ...
      }
    }
    ...
    object myobject = ...;
    // Try double
    PerformList(myobject as List<double>);
    // Try string
    PerformList(myobject as List<string>);
