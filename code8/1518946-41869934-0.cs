	public void Marble()
	{
		string line;
		System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\Main\Desktop\Bitmap.txt");
		//var Speelveld = new Form3();
		//Speelveld.Show();
		int y_row = 0;
		while ((line = file.ReadLine()) != null)
		{
			for (int x_row = 0; x_row < line.Count(); x_row++)
			{
				if (line.Substring(x_row, 1) == "1")
				{
					Speelveld.BackColor = Color.White;
					BackColor = Color.White;
					GameButton testButton = new GameButton(); // ***
					testButton.Currentcolor = false;
					if (x_row == 4 && y_row == 6)
					{
						testButton.BackColor = Color.White;
					}
					else
					{
						Speelveld.Controls.Add(testButton);
						testButton.Startup(x_row , y_row); //***
					}
				}
			}
			y_row++;
		}
	}
