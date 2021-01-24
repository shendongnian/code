    if(originalImage.Width > originalImage.Height)
    {
       x = 0;
       y = (originalImage.Width / 2) - (originalImage.Height / 2);
    }
    else if(originalImage.Width < originalImage.Height)
    {
       y = 0;
       x = (originalImage.Height / 2) - (originalImage.Width / 2);
    }
    else
    {
       y = x = 0;
    }
    int sqrWidth = (originalImage.Width >= originalImage.Height) ? originalImage.Height : originalImage.Width;
    Rectangle crop = new Rectangle(x, y, sqrWidth, sqrWidth);
