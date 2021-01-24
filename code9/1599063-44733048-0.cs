      var list = db.Salaries.Where(g => g.الرقم == emp_comp_code &&
      g.السنة == year && g.الشهر == month).Distinct().ToList();
      var type = list.GetType();
      var props = list[0].GetType().GetProperties();
      List<string> propNames = new List<string>();
      for (var i = 0; i < list.Count; i++)
      {
          foreach (var property in props)
          {
            if(prop.PropertyType == typeof(int)){ 
               var value = int.Parse(prop.GetValue(obj).ToString()
               if ((int)value > 0)
               {
                  propNames.Add(property.Name);
               }
            }
          }
      }
