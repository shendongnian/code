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
                    string a = openFileDialog1.FileName;
                    Image ToBeCropped = Image.FromFile(a, true);
                    ReturnCroppedList(ToBeCropped, 320, 320);
                    pictureBox1.Image = ToBeCropped;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                   pictureBox1.Size = new Size(210, 110);///--add here your desired size
                    AddImagesToButtons(images);
                    break;
                }
            }
        }
    
   
