    private void UpdateListView(int index, string NewName)
        {
                items[index] = NewName;
                items.Sort();
                listViewItemsList.Clear();
            foreach(string item in items)
            {
                ListViewItem Item = new ListViewItem();
                Item.Text = item;
                listViewItemsList.Add(Item);
            }
            listView1.BeginUpdate();
            listView1.VirtualListSize = listViewItemsList.Count;
            listView1.EndUpdate();
        }
    private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            string newName = e.Label;
            listView1.BeginInvoke(new MethodInvoker(() => UpdateListView(e.Item, newName)));
        }
