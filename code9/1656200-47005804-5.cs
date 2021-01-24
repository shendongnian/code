    private void Button1_Click(object sender, EventArgs e)
    {                     
        if(comboBoxBeverage.SelectedItem != null)
        {
            Beverage b = comboBoxBeverage.SelectedItem as Beverage;
            SubTotal += b.Price;
            labelSubtotal.Text = SubTotal.ToString("C");
        }
    }
