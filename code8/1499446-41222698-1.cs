    public void AddItems(ListControl lb, List<string> list)
    {
        ListBox listBox = lb as ListBox;
        ComboBox comboBox = lb as ComboBox;
        foreach (string s in list)
        {
            if (listBox != null && !listBox.Items.Contains(s))
            {
                listBox.Items.Add(s);
            }
            else if (comboBox != null && !comboBox.Items.Contains(s))
            {
                comboBox.Items.Add(s);
            }
        }
    }
