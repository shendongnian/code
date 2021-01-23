    private void Form1_Load(object sender, EventArgs e)
    {
        PictureBox[] boxes = new PictureBox[4];
        boxes[0] = pictureBox0;
        boxes[1] = pictureBox1;
        boxes[2] = pictureBox2;
        boxes[3] = pictureBox3;
    
        ShuffleImages(boxes); //call this method
    
        for (int i = 0; i <= 3; i++)
        {
            switch (i)
            {
                case 0:
                    {  boxes[i].Image = Properties.Resources.dog0;  }
                    break;
                case 1:
                    {  boxes[i].Image = Properties.Resources.dog1;  }
                    break;
                case 2:
                    {  boxes[i].Image = Properties.Resources.dog2;  }
                    break;
                case 3:
                    {  boxes[i].Image = Properties.Resources.dog3;  }
                    break;
            }
        }
    }
