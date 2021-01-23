	public void ProcessClick(object sender, EventArgs e)
    {
        if (mode)
        {
            uxDisplay.Text = _button.ToString();
            mode = false;
        }
        else
        {
            if (uxDisplay.Text == "0")
            {
                uxDisplay.Text = _button.ToString();
            }
            else if (uxDisplay.Text.Length < 8)
            {
                uxDisplay.Text += ((Button)sender).Text;
            }
            else
            {
                return;
            }
        }
    }
