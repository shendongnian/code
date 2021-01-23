     List<string> values = new List<string>();
        private void AddItemProg()
        {
            values.Add("Name");
            values.Add("Age");
            values.Add("DOB");
            values.Add("Address");
            comboBox1.Items.Clear();
            for (int nIndex = 0; nIndex < values.Count; nIndex++)
            {
                string v = values[nIndex];
                comboBox1.Items.Add(v);
            }
        }
