        private void BuildNodes(SqlConnection connection, TreeNodeCollection nodes, string tableName)
        {
            treeView1.BeginUpdate();
            using (var command = new SqlCommand(string.Format("SELECT * FROM Tree", tableName), connection))
            using (var reader = command.ExecuteReader())
            {
                var table = reader.GetSchemaTable();
                foreach (DataRow col in table.Rows)
                    nodes.Add(col[0].ToString());
            }
            treeView1.EndUpdate();
        }
    private void FormTreeLeft_Shown(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=GuardianSoftDB;Integrated Security=True"))
            {
                connection.Open();
                BuildNodes(connection, treeView1.Nodes, "Tree");
                treeView1.ExpandAll();
            }
        }
