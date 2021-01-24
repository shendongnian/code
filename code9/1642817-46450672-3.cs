    private void button2_Click(object sender, EventArgs e)
    {
       double cost = Convert.ToDouble(costTextBox.Text);
       double grossmargin = Convert.ToDouble(grossmarginTextBox.Text);
       double grossSellFinal = cost / (1 - grossmargin);
       sellTextBox.Text = grossSellFinal.ToString();
    }
