    Random randomizer = new Random();
    int count = 0;
    private void BtnDraw_Click(object sender, EventArgs e)
    {
        int randomCardIndex = randomizer.Next(0,53);
        if (count == 0)
        {
            PicCard3.Image = imageList1.Images[randomCardIndex];
            PicCard3.Visible = true;
        }
        else if (count == 1)
        {
            PicCard4.Image = imageList1.Images[randomCardIndex];
            PicCard4.Visible = true;
        }
        else if (count == 2)
        {
            PicCard5.Image = imageList1.Images[randomCardIndex];
            PicCard5.Visible = true;
        }
        else if (count == 3)
        {
            PicCard3.Visible = false;
            PicCard4.Visible = false;
            PicCard5.Visible = false;
            count = -1;
        }
        count++;
    }
