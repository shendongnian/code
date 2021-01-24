    public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ClearAllRichtextboxes();
        if (comboBox5.Text == "Primer")
        {
            richTextBox5.Text = "This is the number of primer tins" + primer.ToString();
        }
        if (comboBox3.Text == "Matt")
        {
            richTextBox6.Text = "This is how many 2.5 tins of paint are needed: " + 
        val44.ToString();
        }
        if (comboBox3.Text == "Vinyl")
        {
            richTextBox6.Text = "This is how many 2.5 tins of paint are needed" + val55;
            richTextBox3.Text = valcm.ToString();
        }
        if (comboBox3.Text =="Silk")
        {
            richTextBox3.Text = valcostsilk.ToString();
        }
    }
