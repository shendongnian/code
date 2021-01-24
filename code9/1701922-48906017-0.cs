    using (var bulkCopy = new SqlBulkCopy(_DbContext.Database.Connection.ConnectionString, SqlBulkCopyOptions.TableLock))
            {
                bulkCopy.BulkCopyTimeout = 1200; // 20 minutes
                //bulkCopy.BatchSize = listTableColumns.Count();
                bulkCopy.BatchSize = 10000;
                bulkCopy.DestinationTableName = "TableA";
                var table = new DataTable();
                var props = TypeDescriptor.GetProperties(typeof(TableA))                                     
                    //Dirty hack to make sure we only have system data types                                      
                    //i.e. filter out the relationships/collections
                    .Cast<PropertyDescriptor>()
                    .Where(propertyInfo => propertyInfo.PropertyType.Namespace.Equals("System"))
                    .ToArray();
                foreach (var propertyInfo in props) 
                { 
                    bulkCopy.ColumnMappings.Add(propertyInfo.Name, propertyInfo.Name); 
                    table.Columns.Add(propertyInfo.Name, Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType); 
                }
                // Add Database ID
                bulkCopy.ColumnMappings.Add("TableAID", "TableAID");
                table.Columns.Add("TableAID", typeof(int));
                var values = new object[props.Length + 1];
                foreach (var item in MyRowsToInsert) 
                { 
                    for (var i = 0; i < values.Length - 1; i++) 
                    { 
                        values[i] = props[i].GetValue(item);
                    }
                    table.Rows.Add(values);
                }
                bulkCopy.WriteToServer(table);
            }
