        class Item
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Item> items = new List<Item>() { new Item() { Name = "Item1", Url = "http://item1" }, new Item() { Name = "Item2", Url = "http://item2" } };
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Url";
            comboBox1.DataSource = items;
            comboBox1.SelectedValueChanged += ComboBox1_SelectedValueChanged;
        }
        private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                MessageBox.Show(comboBox1.SelectedValue.ToString());
            }
                    
        }
