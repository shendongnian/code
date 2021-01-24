    private void txtItem_TextChanged(object sender, EventArgs e)
    {
        int item;
        var row;
        if (int.TryParse(txtItem.Text, out item))
        {
            row = dataSet.PROVIDERS.FindByitem(item);
            if (row != null)
                textBoxProvider.Text = row.provider;
        }
    }
