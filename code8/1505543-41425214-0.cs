     List<string> _items = new List<string>();
        private void clipboardBtn_Click(object sender, EventArgs e)
        {
            string items = Clipboard.GetText();
            _items.Add(items);
            listBox1.DataSource =_items;
        }
