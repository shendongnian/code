	private void SetButtonImage(Button button, int number)
	{
		string imagePath;
		
        if (number == 0)
		{
			imagePath = "empty.jpg";
		}
		else
		{
			imagePath = number + ".jpg";
		}
		
		button.BackgroundImage = Image.FromFile(imagePath);
	}
	
