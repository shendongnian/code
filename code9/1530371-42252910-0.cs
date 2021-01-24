    public static class ExtensionMethods
            {
            /// <summary>
            /// Converts a List to a datatable
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="data"></param>
            /// <returns></returns>
            public static DataTable ToDataTable<T>(this IList<T> data)
                {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
                DataTable dt = new DataTable();
                for (int i = 0; i < properties.Count; i++)
                    {
                    PropertyDescriptor property = properties[i];
                    dt.Columns.Add(property.Name, property.PropertyType);
                    }
                object[] values = new object[properties.Count];
                foreach (T item in data)
                    {
                    for (int i = 0; i < values.Length; i++)
                        {
                        values[i] = properties[i].GetValue(item);
                        }
                    dt.Rows.Add(values);
                    }
                return dt;
                }
            }
