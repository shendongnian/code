    public void Form1_Load(object sender, EventArgs e)
    {
        foreach (TextBox price in groupBoxPrice.Controls.OfType<TextBox>())              
        {
            price.TextChanged += new EventHandler(groupBoxPrice_TextChanged);
        }
    }
    void groupBoxPrice_TextChanged(object sender, EventArgs e)       
    {
        double output = 0;
        TextBox price= (TextBox)sender;
        if(!double.TryParse(price.Text, out output))
        {
            MessageBox.Show("Some Error");
            return;
        }
        else
        {
            Tax tax = new Tax(price.Text);              
            tax.countTax(price.Text);                   
            string labelName = price.Tag.ToString()
            Label l = groupBoxPrice.Controls.OfType<Label>().FirstOrDefault(x => x.Name == labelName);
            if(l != null)
               l.Text = (alv.Tax);                
        }
    }
