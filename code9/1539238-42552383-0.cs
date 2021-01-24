    private void txt_2a_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            validateAnswer(txt_2a.Text);
        }
    }
    private void validateAnswer(string text)
    {
        if (text == "10")
        {
            lblcorrectQ2_1.Visible = true;
        }
        else
        {
            lblincorrectQ2_1.Visible = true;
        }
        txt_2a.Enabled = false;
    }
