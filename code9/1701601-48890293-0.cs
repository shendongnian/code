    private void txtJustification_TextChanged(object sender, EventArgs e)
    {
        var cursorPosition = txtJustification.SelectionStart;
        txtJustification.Text = Regex.Replace(txtJustification.Text, "[^0-9a-zA-Z ]", "");
        txtJustification.SelectionStart = cursorPosition;
    }
