    private void checkerButton_Click(object sender, EventArgs e)
    {
        int input;
        if (int.TryParse(checkerBox.Text, out input))
        {
            pali = new Palindrome() { number = input };
            checkerLabel.Text = pali.GetEvenOrOddMessage();
        }
        else
        {
            // Do something if the input string is not a number
        }
    }
