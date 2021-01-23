            try
            {
                op.Title = "Select a File";
                op.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff|"
       + "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|"
       + "Zip Files|*.zip;*.rar";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    string x = op.FileName.ToString();
                    char[] ayrac = { '.' };
                    string[] kelimeler = x.Split(ayrac);
                    string y = kelimeler[1].ToString();
                                            
                    if (y != "zip" && y != "rar")
                    {
                        pictureBox1.Image = System.Drawing.Image.FromFile(op.FileName);
                        _path = op.FileName;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        //How to get picture: The best way is to put the subfolder under the app's bin\debug\,thus you can simply coding:
                        pictureBox1.Image = Image.FromFile(@"rar.jpg", true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
