    private void InletPercentage_TextBox_TextChanged(object sender, EventArgs e)
    {
        HandleTextBox(InletPercentage_TextBox, OutletPercentage_TextBox);
    }
    private void OutletPercentage_TextBox_TextChanged(object sender, EventArgs e)
    {
        HandleTextBox(OutletPercentage_TextBox, InletPercentage_TextBox);
    }
    private void HandleTextBox(TextBox me, TextBox other)
    {
        // if not enabled then it is not user input and just leave
        if (!me.Enabled) return;
        // if the user has cleared the input, reset other to accept input on both again
        if (string.IsNullOrEmpty(me.Text))
        {
            other.Text = string.Empty;
            other.Enabled = true;
            return;
        }
        // handle user input
        other.Enabled = false;
        int value;
        if (int.TryParse(me.Text, out value) && value >= 0 && value <= 100)
        {
            other.Text = (100 - value).ToString();
        }
        else
        {
            other.Text = string.Empty;
            MessageBox.Show("Invalid input");
        }
    }
