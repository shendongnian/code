    foreach (DataColumn dc in data_table2.Columns)
            {
                //Only new Columns
                if (!data_table1.Columns.Contains(dc.ColumnName))
                {
                    //Add all new Columns to dt1
                    data_table1.Columns.Add(dc.ColumnName, dc.DataType);                    
                    //interate over all rows
                    foreach (DataRow dr in data_table2.Rows)
                    {
                        //Copy single value from  dt2 in dt1
                        data_table1.Rows[dr.Table.Rows.IndexOf(dr)][data_table1.Columns.IndexOf(dc.ColumnName)] = dr[dc.ColumnName];
                    }
                }
            }
