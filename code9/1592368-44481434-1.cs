    decimal total = 0; // variables to hold the total
    private void addButton_Click(object sender, EventArgs e)
      {
             decimal price;     // variables to holds the price
            int counter;
              for (counter=0; counter <= 5; counter++)
               {
               price = decimal.Parse(priceLabel2.Text);
                // add items price 
                total += price;
                // display the total amount 
                 costLabel.Text = total.ToString("c");
              }
