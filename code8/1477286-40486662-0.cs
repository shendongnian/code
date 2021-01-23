    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if(ImageButton1.ImageUrl != "seatreserved.png")
        {
            ImageButton1.ImageUrl = "seatreserved.png";
        }
        else
        {
            ImageButton1.ImageUrl = "seatNotreserved.png";
        }
    }
