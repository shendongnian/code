    private void buttonPalindrom_Click(object sender, EventArgs e)
    {
        string read = textBoxPalindrom.Text.ToLower();
        bool palindrome = IsPalindrome(read);
        if (palindrome )
        {
            MessageBox.Show("je palindrom");
        }
        else
        {
            MessageBox.Show("ni palindrom");
        }
    }
