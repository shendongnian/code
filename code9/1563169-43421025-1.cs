    private bool codeIsChangingText = false;
    private int selectionStart;
    private void txtStart_TextChanged(object sender, EventArgs e)
    {
        if (codeIsChangingText)
        {
            codeIsChangingText = false;
            txtStart.SelectionStart = selectionStart;
        }
        else if (char.IsLower(txtStart.Text.FirstOrDefault()))
        {
            codeIsChangingText = true;
            selectionStart = txtStart.SelectionStart;
            txtStart.Text = char.ToUpper(txtStart.Text.First()) + txtStart.Text.Substring(1);
        }
    }
