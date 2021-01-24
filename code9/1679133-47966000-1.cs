        var userList = uow.Repository<User>().GetAll().ToList();
        DataTable dt = new DataTable();
        dt.Columns.Add("Id");
        dt.Columns.Add("Name");
        foreach (var user in userList)
        {
            var newRow = dt.NewRow();
            newRow["Id"] = user.Id;
            newRow["Name"] = user.Name;
            dt.Rows.Add(newRow);
        }
