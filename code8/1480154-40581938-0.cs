    int cherriesIndex=1;
    private void spinButton_Click(object sender, EventArgs e)
    {
        Random rand = new Random();
        int pic = rand.Next(0, images.Images.Count);
        int pic2 = rand.Next(0, images.Images.Count);
        int pic3 = rand.Next(0, images.Images.Count);
        pictureBox1.Image = images.Images[(pic)];
        pictureBox2.Image = images.Images[(pic2)];
        pictureBox3.Image = images.Images[(pic3)];
        if (pic == cherriesIndex)
        {
            betTextBox.Text = "Winner";
        }` 
