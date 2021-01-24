    List<IDictionary<String, Object>> List = Context.Row_Type.Select(delegate(Row_Type Row) {
        
          IDictionary<String, Object> Out = new ExpandoObject() as IDictionary<String, Object>;
          PropertyInfo[] PIs = Row.GetType().GetProperties();
          foreach(PropertyInfo PI in PIs) {
            if(PI.GetIndexParameters().Length == 0) {
              Out.Add(PI.Name, PI.GetValue(Row));
            }
          }
          return Out;
        }).ToList();
