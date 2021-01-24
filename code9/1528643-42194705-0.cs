    class ItemWrapper
    {
        public object item;
        public string text;
        public int ctr = 1;
        public override string ToString()
        {
            return text + " (" + ctr + ")";
        }
    }
    private void item_img1_Click(object sender, EventArgs e)
    {
        bool found = false;
        foreach (var itm in orderList.Items)
            if ((itm as ItemWrapper).text == item1.Text)
            {
                (itm as ItemWrapper).ctr++;
                found = true;
                break;
            }
        if (!found)
            orderList.Items.Add(new ItemWrapper() { item = item1, text = item1.Text, ctr = 1 });
    }
Where ItemWrapper is wrapper of your item object and overriding ToString() method in it allows listBox to display object as your defined format.
