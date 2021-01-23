    static DataTable ConvertToDatatable(List<Employee> list)
            {
                DataTable dt = new DataTable();
    
                dt.Columns.Add("ID");
                dt.Columns.Add("UserID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Description");
                dt.Columns.Add("StartTime");
                                     
                foreach (var item in list)
                {
                    var row = dt.NewRow();
    
                    row["ID"] = item.ID;
                    row["UserID"] = item.UserID;
                    row["Name"] = item.Name;
                    row["Description"] = item.Description;
                    row["StartTime"] = item.StartTime;
                             
    
                    dt.Rows.Add(row);
                }
    
                return dt;
            }
