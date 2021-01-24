    // the icon file with one single star
    var starIcon = Image.FromFile(...);
    // the image of all stars (the width has to be the width of one star multiplied by the count of stars)
    var image = new Bitmap(starsCount * starIcon.Width, starIcon.Height);
    using (var g = Graphics.FromImage(image))
    {
        for (int i = 0; i < starCount; i++)
        {
            // place the star icon to its position in the loop
            int x = (i * starIcon.Width);
            // https://msdn.microsoft.com/de-de/library/dbsak4dc(v=vs.110).aspx
            g.DrawImage(starIcon, x, 0, starIcon.Width, starIcon.Height);
        }
        g.Flush();
    }
