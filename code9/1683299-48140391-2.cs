    int count = 0;
    
        private void button1_Click(object sender, EventArgs e)
        {
            if (count == 0)
            {
                //Make PictureBox1 visible
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                count++;
            }
            else if (count == 1)
            {
                //Make PictureBox2 visible
                pictureBox2.Visible = true;
                pictureBox1.Visible = false;
                pictureBox3.Visible = false;
                count++;
            }
            else if (count == 2)
            {
                //Make PictureBox3 visible
                pictureBox3.Visible = true;
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                count = 0;
            }
        }
