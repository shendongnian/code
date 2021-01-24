      private void BindComboBoxItem()
        {
            ItemRepository repo = new ItemRepository();
            List<Item> items = repo.GetAll();
            List<KeyValuePair<int, string>> allitems = new List<KeyValuePair<int, string>>();
            KeyValuePair<int, string> first = new KeyValuePair<int, string>(0, "Please Select");
            allitems.Add(first);
            foreach (Item item in items)
            {
                KeyValuePair<int, string> obj = new KeyValuePair<int, string>(item.Id, item.Name);
                allitems.Add(obj);
            }
            cbxSelectItem.DataSource = allitems;
            cbxSelectItem.DisplayMember = "Value";
            cbxSelectItem.ValueMember = "Key";
        }
