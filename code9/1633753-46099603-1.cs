        private void LoadBtn_Click(object sender, EventArgs e) {
            int i = 0;
            treeView1.Nodes.Clear();
            while (i < dt.Rows.Count) {
                DataRow row = dt.Rows[i];
                string customer = row.Field<string>(2);
                TreeNode customerNode = treeView1.Nodes.Add(customer);
                while (i < dt.Rows.Count && row.Field<string>(2) == customer) {
                    string schedule = row.Field<string>(0);
                    TreeNode scheduleNode = customerNode.Nodes.Add(schedule);
                    while (i < dt.Rows.Count && row.Field<string>(2) == customer && schedule == row.Field<string>(0)) {
                        
                        string report = row.Field<string>(1);
                        scheduleNode.Nodes.Add(report);
                        if (++i < dt.Rows.Count)
                            row = dt.Rows[i];
                    }
                }
            }
        }
