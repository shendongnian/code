        ListViewItem _result = null;
        public ListViewItem Result { get { return _result; } }
        public List<ListViewItem> Source
        {
            set
            {
                listView1.Items.Clear();
                foreach (ListViewItem item in value)
                    listView1.Items.Add(item);
                listView1.View = View.List;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_result == null)
                return;
            DialogResult = DialogResult.OK;
            Close();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView list = (ListView)sender;
            ListView.SelectedIndexCollection indices = list.SelectedIndices;
            if (indices.Count == 0)
                return;
            _result = list.Items[indices[0]];
        }
