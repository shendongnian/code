    private void button2_Click(object sender, EventArgs e)
    {
        double totalValue = 0;
        foreach (var textBox in textBoxes)
        {
            double currentValue;
            if (double.TryParse(textBox.Text, out currentValue))
            {
                totalValue += currentValue;
            }
        }
        // Displaying totalValue in a label.
        lblTotalValue.Text = "Total Value : " + totalValue;
    }
