            DataTable table = new DataTable();
            table.Clear();
            table.Columns.Add("Username");
            table.Columns.Add("Marks");
            DataRow dataRow = table.NewRow();
            dataRow["Username"] = "xyz";
            dataRow["Marks"] = "500";
            table.Rows.Add(dataRow);
            var username = "xyz";
            DataRow[] user = table.Select("Username = '" + username + "'");
            if(user.Length > 0 )
            table.Rows.IndexOf(user[0]);
