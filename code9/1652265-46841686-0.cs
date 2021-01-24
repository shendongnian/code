    private void calcButton_Click(object sender, EventArgs e)
    {
        int[] areaCode = { 262, 414, 608, 715, 815, 902 };
        double[] rates = { 0.07, 0.10, 0.05, 0.16, 0.24, 0.14 };
        if(!string.IsNullOrEmpty(areaCodeTextBox.Text))
        {
        	double total = 0;
        	if(!string.IsNullOrEmpty(callTimeTextBox.Text))
        	{
        		int index = Array.IndexOf(areaCode, int.Parse(areaCodeTextBox.Text)); //You can use TryParse to catch for invalid input
        		if(index > 0)
        		{
        			total = Convert.ToInt32(callTimeTextBox.Text) * rates[index];
        			costResultsLabel.Text = "Your " + callTimeTextBox.Text + "-minute call to area code " + areaCodeTextBox.Text + " will cost " + total.ToString("C");
        		}
        	}
        }
    }
