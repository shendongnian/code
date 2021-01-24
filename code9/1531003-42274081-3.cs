    private void button1_Click(object sender, EventArgs e)
    {
        string display;         
        double initialfee = 12000.00;
        double increase,newfee;
        double rate = 0.02;
        listBox1.Items.Clear();
        for (int year = 1; year <= 5; year++)
        {
           newfee = initialfee + (initialfee * 2/100 * year);
           display = "year " + year.ToString() + ": " + "  Amount " + "$" + newfee;
        }
    }
