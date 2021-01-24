        private readonly Dictionary<string, int> _dict = new Dictionary<string, int>();
        private void AddNewItem(string item)
        {
            if (_dict.ContainsKey(item)) _dict[item]++;
            else _dict.Add(item,1);
            listBox1.Items.Clear();
            foreach (KeyValuePair<string, int> kvp in _dict)
            {
                if (kvp.Value > 1) listBox1.Items.Add(kvp.Key + " X" + kvp.Value);
                else listBox1.Items.Add(kvp.Key);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddNewItem("ItemName");
        }
