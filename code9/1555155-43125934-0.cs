    private void expenses_KeyDown(object sender, KeyEventArgs e)
    {
    	try
    	{
    		if (expenses.Text != string.Empty)
    		{
    			double Pprice = Convert.ToDouble(buyTotal.Text);
    			double expens = Convert.ToDouble(expenses.Text);
    			double final = Pprice + expens;
    			buyTotal.Text = final.ToString("0.00");
    		}
		    else
		    {
			    buyTotal.Text="0.00";
		    }
    	}
    	catch(Exception exc)
    	{
    		buyTotal.Text="0.00";
    	}
    }
