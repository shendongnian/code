    //assuming Winforms. Code for a web site will look a bit different:
    private void button1_Click(object sender, EventArgs e)
    {
        int quantity, alertlevel;
        if (!int.TryParse(txtQuantity.Text, out quantity))
        {
           MessageBox.Show("Enter a valid number for the quantity.");
           return;
        }
        if (!int.TryParse(txtQuantity.Text, out alertlevel))
        {
           MessageBox.Show("Enter a valid number for the alert level.");
           return;
        }
        inventory.Add(new Item() {Name = txtName.Text, Quantity = quantity, AlertLevel = alertlevel});
    }
