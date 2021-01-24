    public static DataTable ToDataTable<T>(this IList<T> list)
          {
             DataTable table = null;
             if (list != null && list.Count > 0)
             {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
    
                List<PropertyDescriptor[]> propList = new List<PropertyDescriptor[]>();
    
                table = new DataTable();
                foreach (PropertyDescriptor item in properties)
                {
                   if (IsArrayOrCollection(item.PropertyType))
                   {
                      continue;
                   }
                   AddColumnsForProperties(typeof(T).Namespace, null,  table, (new[] { item }).ToList(), ref propList);
                }
    
                object[] values = new object[propList.Count];
    
                foreach (T item in list)
                {
                   for (int i = 0; i < values.Length; i++)
                      values[i] = GetValueFromProps(propList[i], item) ?? DBNull.Value;
    
                   table.Rows.Add(values);
                }
             }
             return table;
          }
      private static object GetValueFromProps(PropertyDescriptor[] descriptors, object item)
      {
         var result = item;
         foreach (var descriptor in descriptors)
         {
            if (result != null)
            {
               result = descriptor.GetValue(result);
            }
         }
         return result;
      }
      private static void AddColumnsForProperties(string myNamespace, string parentName, DataTable dt, List<PropertyDescriptor> p, ref List<PropertyDescriptor[]> properties)
      {
         var pLast = p.Last();
         if (pLast.PropertyType.Namespace != null && pLast.PropertyType.Namespace.StartsWith(myNamespace))
         {
            var allProperties = pLast.GetChildProperties();
            if (allProperties.Count > 0)
            {
               foreach (PropertyDescriptor item in allProperties)
               {
                  var newP = p.ToList();
                  newP.Add(item);
                  string childParentName = !String.IsNullOrEmpty(parentName)
                     ? String.Format("{0}.{1}.{2}", parentName, pLast.Name, item.Name)
                     : String.Format("{0}.{1}", pLast.Name, item.Name);
                  if (item.PropertyType.Namespace != null && item.PropertyType.Namespace.ToLower().StartsWith(myNamespace))
                  {
                     AddColumnsForProperties(myNamespace, childParentName, dt, newP, ref properties);
                  }
                  else if (!dt.Columns.Contains(childParentName))
                  {
                     dt.Columns.Add(childParentName, Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType);
                     properties.Add(newP.ToArray());
                  }
               }
            }
            else if (!dt.Columns.Contains(pLast.Name))
            {
               dt.Columns.Add(pLast.Name, Nullable.GetUnderlyingType(pLast.PropertyType) ?? pLast.PropertyType);
               properties.Add(p.ToArray());
            }
         }
         else if (!dt.Columns.Contains(pLast.Name))
         {
            dt.Columns.Add(pLast.Name, Nullable.GetUnderlyingType(pLast.PropertyType) ?? pLast.PropertyType);
            properties.Add(p.ToArray());
         }
      }
