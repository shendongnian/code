	public void generateButtonsCard(Panel cardPanel)
	{
		for (int y = 0; y <= 4; y++)
		{
			for (int x = 0; x <= 4; x++)
			{
				var button = new Button();
				button.Size = new Size(80, 80);
				button.Name = "btn" + x + "" + y;
				button.Location = new Point(80 * x, 80 * y);
				button.Click += (s, e) =>
				{
					/* Your event handling code here
					   with full access to `button` above */
				};
				cardPanel.Controls.Add(button);
				cardButtons[x, y] = button;
			}
		}
		RNGCard();
		cardButtons[2, 2].Text = "Free Space";
	}
