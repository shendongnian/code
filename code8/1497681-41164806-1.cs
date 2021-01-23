    original600x600 = new Bitmap(600, 600);
    //Draw the portion of your 1000x1000 to your 600x600 image
    ....
    ....
    
    //create the image of your pictureBox
    picBoxImage= new Bitmap(400, 400);
    //scale the image in picBoxImage
    Graphics gr;
    gr = Graphics.FromImage(picBoxImage);
    gr.DrawImage(original600x600, new Rectangle(0, 0, 400, 400));
    gr.Dispose();
    gr = null;
    pictureBox1.Image = picBoxImage; //If at any time you want to change the image of
                                     //pictureBox1, you dont't draw directly on the control
                                     //but on picBoxImage and then Invalidate()
