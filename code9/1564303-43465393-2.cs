    private void txt_pay2_TextChanged(object sender, EventArgs e)
    {
        string text1 = pay_dues.Text.Trim();
        string text2 = txt_pay2.Text.Trim();
        try
        {
            if (!string.IsNullOrEmpty(text1 ))
            {
                // Validate both textboxes have numeric values:
                Regex numericRegex = new Regex(@"^-?\d*(\.\d+)?$");
                if ( (numericRegex.IsMatch(text1)) &&
                     (numericRegex.IsMatch(text2)) )
                {
                    txt_dues2.Text = (Convert.ToInt32(text1) - Convert.ToInt32(text2)).ToString();
                }
                else
                {
                    MessageBox.Show("Please enter only numbers !");
                    return;
                }
    
            }
            else if (String.IsNullOrEmpty(txt_pay2.Text))
            {
                MessageBox.Show("Please enter an amount.");
            }
        }
        catch (Exception Ex)
        {
    
            MessageBox.Show(Ex.Message);
        }
    }
