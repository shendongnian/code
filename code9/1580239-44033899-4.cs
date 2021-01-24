	foreach (Button b in game_panel1.Controls)
	{
		OpenFileDialog openFileDialog1 = new OpenFileDialog();
		openFileDialog1.Filter = "JPG|*.jpg;*.jpeg|PNG|*.png";
		// openFileDialog1.InitialDirectory = @"C:\Users\DELL_PC";
		if (openFileDialog1.ShowDialog() != DialogResult.OK)
		{
			break;
		}
		else
		{
			bool correctSize=false;
			var imageH=null;
			var imageW=null
					while(!correctSize) //make a loop so only desired size will be taken 
					{
						string a = openFileDialog1.FileName;
						Image ToBeCropped = Image.FromFile(a, true);
						*ReturnCroppedList(ToBeCropped, 320, 320);
						pictureBox1.Image = ToBeCropped;
						pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
						if(PictureBox1.Image.Size.Width==yourWidth && PictureBox1.Image.Size.height==yourHeight) //Validate size 
						{ correctSize =true; 
						  AddImagesToButtons(images);
						break;
						}
						else 
							MessageBox.Show("Please enter image size your desired size ")
					}
		}
	}
