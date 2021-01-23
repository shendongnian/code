     foreach (DataRow row in data.Rows)
                    {
                        assignment_group_dim_temp a = new assignment_group_dim_temp();
                        foreach (DataColumn column in data.Columns)
                        {
                            string colName = column.ColumnName.ToString();
                            string colData = row[column].ToString();
                            
                            //How can I assign the following variable?
                            **a.colName = colData;**
                            agd.Add(a);
                        }
                    }
