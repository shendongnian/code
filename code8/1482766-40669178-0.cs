    int input1 = 0;
    int input2 = 0;
    
    try
    {
    	input1 = Convert.ToInt32(textBoxTranspo.Text);
    	input2 = Convert.ToInt32(textBoxDaily.Text); 
        ans = input1 + input2;
    
    	if (!string.IsNullOrEmpty(textBoxTranspo.Text) && !string.IsNullOrEmpty(textBoxDaily.Text))
    	{
    		textBoxTotalAmount.Text = ans.ToString();
    	}
    
    }
    catch (Exception)
    {
    	textBoxTotalAmount.Text = "Invalid input";
    }
