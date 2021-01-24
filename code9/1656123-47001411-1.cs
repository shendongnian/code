    private void btnSil_Click(object sender, EventArgs e)
    {
        Control groupBox = ((Button)sender).Parent;
        this.Controls.Remove(groupBox);
        groupBox.Dispose();
    }
