    private void AddItem(string item)
    {
        var v = Items.FirstOrDefault(x => x.Equals(item));
        if (v != default(string))
        {
            //SelectedItem = v;
            Task.Run(() => SelectedItem = v);
        }
        else
        {
            Items.Add(item);
            SelectedItem = item;
        }
    }
