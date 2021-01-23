    private void btnFindDem_Click(object sender, EventArgs e)
    {
        int twenties = 0, 
            tens = 0, 
            fives = 0, 
            singles = 0,
            totDollars = Convert.ToInt32(txtDollars.Text);
        lstOut.Items.Add("Total dollars = " + totDollars.ToString("c"));
        while (totDollars >= 20)
        {
            totDollars -= 20;
            twenties++;
        }
        while (totDollars >= 10)
        {
            totDollars -= 10;
            tens++;
        }
        while (totDollars >= 5)
        {
            totDollars-= 5;
            fives++;
        }
        while (totDollars >= 1)
        {
            totDollars--;
            singles++;
        }
        lstOut.Items.Add("Twenties: " + twenties);
        lstOut.Items.Add("Tens: " + tens);
        lstOut.Items.Add("Fives: " + fives);
        lstOut.Items.Add("Ones: " + singles);
    }
