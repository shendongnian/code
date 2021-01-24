    private void InletPercentage_TextBox_TextChanged(object sender, EventArgs e)
    {
        HandleTextBox(InletPercentage_TextBox,OutletPercentage_TextBox);
    }
    private void OutletPercentage_TextBox_TextChanged(object sender, EventArgs e)
    {
        HandleTextBox(OutletPercentage_TextBox, InletPercentage_TextBox);
    }
    private void HandleTextBox( TextBox me, TextBox other )
    {
        // need to reset?
        if (me.Text == string.Empty)
        {
            other.Text = string.Empty;
            me.Enabled = true;
            return;
        }
        // is this really a user input?
        // if not Enabled it is impossible for the user to input anything
        if (!me.Enabled)
        {
            return;
        }
        // handle user input
        int value;
        if (int.TryParse(me.Text, out value) && value >= 0 && value <= 100)
        {
            other.Enabled = false;
            other.Text = (100 - value).ToString();
        }
        else
        {
            me.Text = string.Empty;
        }
    }
