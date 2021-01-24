	private Dictionary<Button, Image> dicButtonsBaseImage = new Dictionary<Button, Image>();
	private void SetImageButton(Button btn, Image img)
	{
		// Initiate image for button
		btn.Image = img;
		
		// set method dor sizeChanged
		btn.SizeChanged += Control_SizeChanged;
		
		// Save image associated for this button
		if (!dicButtonsBaseImage.ContainsKey(btn))
			dicButtonsBaseImage.Add(btn, img);
		else
			dicButtonsBaseImage[btn] = img;
			
		// Init image size
		resizeImageSize(btn);
	}
	
	private void Control_SizeChanged(object sender, EventArgs e)
	{
		Control c = sender as Control;
		if (c != null)
		{
			Button b = sender as Button;
			if (b != null)
			{
				resizeImageSize(b);
			}
		}
	}
	
	private static void resizeImageSize(Button b)
	{
		if (b.Image != null && dicButtonsBaseImage.ContainsKey(b))
		{
			// Set a margin (top/bot) to 8px
			if (b.Height - 8 < dicButtonsBaseImage[b].Height)
			{
				int newHeight = b.Height - 8;
				if (newHeight <= 0)
					newHeight = 1;
				Image img = new Bitmap(dicButtonsBaseImage[b], new Size(dicButtonsBaseImage[b].Width, newHeight));
				b.Image = img;
			}
			else
			{
				b.Image = dicButtonsBaseImage[b];
			}
		}
	}
