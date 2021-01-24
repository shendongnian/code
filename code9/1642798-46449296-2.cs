    private void chkLstBx_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (e.Index == 0)
        {
            if (e.NewValue == CheckState.Checked)
                ChangeAllCheckBoxValues(true);
            else
                ChangeAllCheckBoxValues(false);
        }
    }
    private void ChangeAllCheckBoxValues(bool value)
    {
        for (int i = 1; i < chkLstBx.Items.Count; i++)
        {
            chkLstBx.SetItemChecked(i, value);
        }
    }
