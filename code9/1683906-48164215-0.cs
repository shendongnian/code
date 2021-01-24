    protected void rblDocumentstType_SelectedIndexChanged(Object sender, EventArgs e)
    {
        RadioButtonList rblDocumentstType = (RadioButtonList) sender;
        if(rblDocumentstType.SelectedIndex == 1)
        {
            txtRFP.Focus();
        }
    }
