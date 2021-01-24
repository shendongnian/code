    bool hasEditColumn = false;
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                if (item.GetType() == typeof(DataGridViewLinkColumn) && item.HeaderText == "Edit")
                {
                    hasEditColumn = true;
                    break;
                }
            }
            if (!hasEditColumn)
            {
                DataGridViewLinkColumn EditLink = new DataGridViewLinkColumn();
                EditLink.UseColumnTextForLinkValue = true;
                EditLink.HeaderText = "Edit";
                EditLink.DataPropertyName = "lnkColumn";
                EditLink.LinkBehavior = LinkBehavior.SystemDefault;
                EditLink.Text = "Edit";
                dataGridView1.Columns.Add(EditLink);
                dataGridView1.Refresh();
            }
