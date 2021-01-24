    private void textBoxX1_TextChanged(object sender, TextChangedEventArgs e)
    {
        double value = 0.00;
        if (double.TryParse(textBoxX1.Text, out value))
        {
            textBoxX1.Text = string.Format("{0:F}", value);
            string txtval = value.ToString();
        }       
    }
