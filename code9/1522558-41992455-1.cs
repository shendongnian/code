    public void SelectItem(string key)
            {
                var comboItem = comboBox1.Items
                    .Cast<ComboboxItem>()
                    .FirstOrDefault(item => item.Key.Equals(key));
                if (comboItem == null)
                {
                    //do whatever you want
                }
                else
                {
                    comboBox1.SelectedItem = comboItem;
                }
            }
