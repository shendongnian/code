    private void calcButton_Click(object sender, EventArgs e)
    {
        int[] areaCode = { 262, 414, 608, 715, 815, 902 };
        double[] rates = { 0.07, 0.10, 0.05, 0.16, 0.24, 0.14 };
        int inputAC;
        double total = 0;
    
        for (int x = 0; x < areaCode.Length; ++x)
        {    
            inputAC = Convert.ToInt32(areaCodeTextBox.Text);
            total = Convert.ToInt32(callTimeTextBox.Text) * rates[x];
            
            if(inputAC == areaCode[x]) //ADDED condition
            	break;
        }
        costResultsLabel.Text = "Your " + callTimeTextBox.Text + "-minute call to area code " + areaCodeTextBox.Text + " will cost " + total.ToString("C");
    }
