	private void Form1_KeyDown(object sender, KeyEventArgs e)
	{
		//when one of the movement keys are pressed, 
		//makes it's variable true.
		if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
		{
			if (!moveRight)
			{
				picPlayer.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
				moveRight = true;
			}		
		}
	}
