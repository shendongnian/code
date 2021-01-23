    bool CmpVal<T1, T2>(T1 val1, T2 val2)
    {
         var listCompareColumns = new List<CompareColumns>();
         //fill list values
         return listCompareColumns
                  .All(q => typeof(T1).GetProperty(q.Columns, BindingFlags.Public | 
                                                              BindingFlags.Instance)
                                      .GetValue(val1) ==
                            typeof(T2).GetProperty(q.Columns, BindingFlags.Public | 
                                                              BindingFlags.Instance)
                                      .GetValue(val2));
    }
