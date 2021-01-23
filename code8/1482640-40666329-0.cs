    private void button1_Click(object sender, EventArgs e)
            {
                ++NumberOfClick;
                switch (NumberOfClick)
                {
                    case 1:
                        OpenFileDialog f = new OpenFileDialog();
                        f.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
    
                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            File = Image.FromFile(f.FileName);
                            pictureBox1.Image = File;
                        }
    
                        break;
                    case 2:
                        OpenFileDialog f2 = new OpenFileDialog();
                        f2.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
    
                        if (f2.ShowDialog() == DialogResult.OK)
                        {
                            File = Image.FromFile(f2.FileName);
                            pictureBox2.Image = pictureBox1.Image;
                            pictureBox1.Image = File;
                        }
                        break;
                    case 3:
                        OpenFileDialog f3 = new OpenFileDialog();
                        f3.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
    
                        if (f3.ShowDialog() == DialogResult.OK)
                        {
                            File = Image.FromFile(f3.FileName);
                            pictureBox3.Image = pictureBox2.Image;
                            pictureBox2.Image = pictureBox1.Image;
                            pictureBox1.Image = File;
                        }
                        break;
                    case 4:
                        OpenFileDialog f4 = new OpenFileDialog();
                        f4.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
    
                        if (f4.ShowDialog() == DialogResult.OK)
                        {
                            File = Image.FromFile(f4.FileName);
                            pictureBox4.Image = pictureBox3.Image;
                            pictureBox3.Image = pictureBox2.Image;
                            pictureBox2.Image = pictureBox1.Image;
                            pictureBox1.Image = File;
                        }
    
                        break;
                    default:
                        // other clicks
                        // . . .
                        break;
    
                }
            }
