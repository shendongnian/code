    public DialogResult ConfirmationMessageBoxTemplate(string Confirmation)
    {
        return MetroMessageBox.Show(new frmMainWindow(), Confirmation, "Notice", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question);
    }
----------
    DialogResult result = ConfirmationMessageBoxTemplate("Hello World");
    if (result == DialogResult.OK )
        MessageBox.Show ("User clicked OK button");
    else if (result == DialogResult.Cancel)
        MessageBox.Show ("User clicked Cancel button");
