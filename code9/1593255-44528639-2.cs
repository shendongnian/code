    private void inputBox_TextChanged(object sender, EventArgs e)
    {
        if (hexRadioButton.Checked)
        {
            var allowedValues = new[] 
            {
                'A', 'B', 'C', 'D', 'E', 'F',
                'a', 'b', 'c', 'd', 'e', 'f',
                '1', '2', '3', '4', '5', '6',
                '7', '8', '9', '0', '-'
            };
            var validString = new StringBuilder();
            var validChrIndex = 1;
            for (int i = 1; i <= inputBox.TextLength; i++)
            {
                var chr = inputBox.Text[i - 1];
                if (!allowedValues.Contains(chr)) continue;
                if (validChrIndex % 3 == 0)
                {
                    if (chr != '-')
                    {
                        validString.Append('-');
                        validChrIndex++;
                    }
                }
                else if (chr == '-')
                {
                    continue;
                }
                validString.Append(chr);
                validChrIndex++;
            }
            if (!validString.ToString().Equals(inputBox.Text))
            {
                inputBox.Text = validString.ToString();
                inputBox.SelectionStart = inputBox.TextLength;
            }
        }
    }
