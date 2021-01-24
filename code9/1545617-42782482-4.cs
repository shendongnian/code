    public void SetUpdatable()
    {
        var canUpdate = VerifyAllRows(tbItem.Text);
        if (canUpdate)
        {
            btnAdd.Enabled = true;
            lblAdd.Text = "Accepted";
        }
        else
        {
           btnAdd.Enabled = false;
           lblAdd.Text = "Item name cannot be the same";
        }
    }
