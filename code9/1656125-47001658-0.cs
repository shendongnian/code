    private void btnSil_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GroupBox gb = (GroupBox)btn.Tag;
        gb.Dispose(); // will automatically remove it as well
    }
