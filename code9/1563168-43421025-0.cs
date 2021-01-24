    private bool codeIsChangingText = false;
    private void txtStart_TextChanged(object sender, EventArgs e)
    {
        if (codeIsChangingText)
        {
            codeIsChangingText = false;
        }
        else
        {
            if (char.IsLower(txtStart.Text.FirstOrDefault()))
            {
                codeIsChangingText = true;
                txtStart.Text = char.ToUpper(txtStart.Text[0]) + txtStart.Text.Substring(1);
            }
        }
    }
