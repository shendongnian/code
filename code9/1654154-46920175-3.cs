    protected void bindSecondComboBox(string selValue)
    {
        comboBox2.Items.Clear();
        if (selValue == "Shoes")
        {
            comboBox2.Items.Add("Rockport");
            comboBox2.Items.Add("Addidas");
            comboBox2.Items.Add("Nike");
        }
        else if (selValue == "Watches")
        {
            comboBox2.Items.Add("Tagheuer");
            comboBox2.Items.Add("Rolex");
            comboBox2.Items.Add("Victus");
        }
        else if (selValue == "Tvs")
        {
            comboBox2.Items.Add("Sony");
            comboBox2.Items.Add("Samsung");
            comboBox2.Items.Add("Toshiba");
        }
    }
