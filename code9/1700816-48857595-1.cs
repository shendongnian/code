    if ( counter >= 4 && !My_Pizza.Items.Contains(tuna) )
    {
    	MessageBox.Show("You have more than 4 toppings, Remove then replace one");
    {
    else	
    {
    	if (!My_Pizza.Items.Contains(tuna))
    	{
    		My_Pizza.Items.Add(tuna);
    		labelTuna.BackColor = Color.Green;
    		counter++;
    	}
    	else
    	{
    		My_Pizza.Items.Remove(tuna);
    		labelTuna.BackColor = Color.LightSteelBlue;
    		counter--;
    	}
    }
