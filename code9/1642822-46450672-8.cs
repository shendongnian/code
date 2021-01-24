    private void button2_Click(object sender, EventArgs e)
    {
       decimal cost = Convert.ToDecimal(costTextBox.Text);
       decimal grossmargin = Convert.ToDecimal(grossmarginTextBox.Text);
       if (grossmargin > 100)
       {
           sellTextBox.Text = "Error message here";
       }
       else 
       {
           decimal grossSellFinal = cost / (1 - grossmargin/100);
           sellTextBox.Text = grossSellFinal.ToString();
       }
    }
