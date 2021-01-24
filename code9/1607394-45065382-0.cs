    using (OleDbConnection conn = new OleDbConnection(connString))
        {
            OleDbCommand comm = new OleDbCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            string txt = "SELECT* FROM [ListForGroup] WHERE [email] = @email";
            comm.Parameters.Add("@email", OleDbType.VarWChar).Value = userEmail;
            comm.CommandText = txt;
            conn.Open();
            OleDbDataReader reader = comm.ExecuteReader();
            List<ListForGroups> list = returnLists(reader);
            cmbSelectList.DataSource = list;
            cmbSelectList.DisplayMember = "listName";
            cmbSelectList.ValueMember = "listForGroupsID";
        }
