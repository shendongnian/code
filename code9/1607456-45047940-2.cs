        private void button1_Click(object sender, EventArgs e)
        {
            //add Columns, which you might have done in designer
            //this.testListView.Columns.Add...
            this.testListView.View = View.Details;
            var list = List1.Except(List2).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                ListViewItem item = new ListViewItem(list[i]);
                this.testListView.Items.Add(item);
            }
        }
