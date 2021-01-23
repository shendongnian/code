        private void Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 4);
            switch (randomNumber)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources._01;
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources._02;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources._03;
                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources._04;
                    break;
            }
        }
