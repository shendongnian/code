    foreach (DataRow row in csvDataTable.Rows)
            {
                if (row["ID"].ToString() == "")
                {
                    invalidated = true;
                    row["ID"] = "not valid";
                }
               if (row["Name"].ToString() != "test")
                {
                    invalidatedTable.Rows.Add(row.ItemArray);
                }
            }
