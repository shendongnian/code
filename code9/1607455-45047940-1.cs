        private void button1_Click(object sender, EventArgs e)
        {
            //add Columns, which you might have done in designer
            //this.testListView.Columns.Add...
            this.testListView.View = View.Details;
            var list = List1.Except(List2).ToString();
            if (list.Count == 0)
                return;
            ListViewItem item = new ListViewItem(list[0]);
            for (int i = 1; i < list.Count; i++)
                item.SubItems.Add(list[i]);
            this.testListView.Items.Add(item);
        }
