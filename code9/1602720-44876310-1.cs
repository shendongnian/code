    public string AddMessageInfo { get; private set; }
    private void btnOK_Click(object sender, EventArgs e)
    {
        AddMessageInfo = textBoxAddWinForm.Text; // Set AddMessageInfo
        this.DialogResult = DialogResult.OK; // Let parent form know you pressed OK
        this.Close(); // Close this form
    }
