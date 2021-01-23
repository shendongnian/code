    DataTable GetTableWithUniqueColumn()
            {
                DataTable table = new DataTable();
                table = GetDataFromDB(); //  dynamically getting data from different tables via joins
                table.Columns.Add("UniqueColumn", typeof(Guid));
                foreach (DataRow row in table.Rows)
                {
                    row["UniqueColumn"] = Guid.NewGuid();
                }
    
                return table;
            }
