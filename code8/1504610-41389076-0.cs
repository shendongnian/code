    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        string fileLocation = "Get File Location";              //WHERE IS THE IMAGE LOCATED?  DON'T FORGET FILE EXTENTIONS!!
        //Graphics g = e.Graphics;                              //GRAPHICS INSTANCE
        Image img = Image.FromFile(fileLocation);               //IMAGE INSTANCE
        //  IF YOU PLACED A PICTUREBOX IN YOUR FORM.
        Size maxSize = new Size();                              //CREATE SIZE MAXIMUMS FOR THE LARGEST YOU WANT AN IMAGE TO BE
        Size imgSize = new Size();                              //FIND THE IMAGE SIZE FOR COMPARISON
        maxSize.Width = 600;                                    //SET MAX WIDTH
        maxSize.Height = 600;                                   //SET MAX HEIGHT
        imgSize.Width = img.Width;                              //FIND IMAGE WIDTH
        imgSize.Height = img.Height;                            //FIND IMAGE HEIGHT
        pbImage.MaximumSize = maxSize;                          //MAKE SURE WE DONT GO PAST OUR MAX SIZE
        pbImage.BackgroundImageLayout = ImageLayout.Stretch;    //MAKE SURE THE IMAGE STRETCHES TO THE SIZE OF THE PICTURE BOX
        //HERE, WE RUN A SERIES OS CHECKS TO SEE HOW BIG TO MAKE OUR PICTURE BOX
        if (imgSize.Height < maxSize.Height && imgSize.Width < maxSize.Width)           //IF THE PICTURE IS SMALLER THAN THE MAX SIZE
            pbImage.Size = imgSize;                                                     //SET THE SIZE TO THAT OF THE PICTURE
        else if (imgSize.Height > maxSize.Height || imgSize.Width > maxSize.Width)      //IF THE WIDTH OR HEIGHT ARE LARGER THAN THE MAX
        {
            //SET HEIGHT
            if (imgSize.Height < maxSize.Height)                                        
                pbImage.Height = imgSize.Height;
            else pbImage.Height = maxSize.Height;
            //SET WIDTH
            if (imgSize.Width < maxSize.Width)
                pbImage.Width = imgSize.Width;
            else pbImage.Width = maxSize.Width;
        }
        else if (imgSize.Height > maxSize.Height && imgSize.Width > maxSize.Width)      //IF THE IMAGE IS BIGGER THAN OUR MAX
            pbImage.Size = maxSize;                                                     //MAKE IT THE SIZE OF THE MAX
        pbImage.Image = img;                                                            //PUT THE IMAGE IN THE BOX
            
        //  IF YOU DIDN'T - YOU SHOULD.  IT'S FAR MORE CONTROLLED
        //g.DrawImage(img, 0, 0, (float)img.Width, (float)img.Height);
    }
