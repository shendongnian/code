	int baseNumber; // you can do 2 here as well
	public YourFormName() 
	{
		baseNumber = 2; 
	}  
	private void drawButton_Click(object sender, RoutedEventArgs e)  
	{
		int losingStraw = Convert.ToInt32(drawButton.Tag);   
		if (baseNumber < losingStraw)
		{
			instructions.Text = "You are safe!";
			baseNumber = baseNumber++; // that doesn't work at all. I was hoping that baseNumber
		}
		else
		{
			instructions.Text = "You have drawn the losing straw";
		}
	}
