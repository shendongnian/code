    private void textBoxItem_TextChanged(object sender, EventArgs e)
    {
        int item;
        var row;
        if (int.TryParse(textBoxItem.Text, out item))
        {
            row = dataSet.PROVIDERS.FindByitem(item);
            if (row != null)
                textBoxProvider.Text = row.provider;
        }
    }
