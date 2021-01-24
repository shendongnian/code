    // get the screen width
    var metrics = Resources.DisplayMetrics;
    var widthInDp = (int)((metrics.WidthPixels) / metrics.Density);
    // this line is very specific, it calculates the real usable space
    // in my case, there was padding of 5dp nine times, so subtract it
    var space = widthInDp - 9 * 5;
    // and in this usable space, I had 7 identical TextViews, so a limit for one is:
    var limit = space / days.Length;
    
    // now calculating the text length in dp            
    Paint paint = new Paint();
    paint.TextSize = myTextView.TextSize;
    var textLength = (int)Math.Ceiling(paint.MeasureText(myTextView.Text, 0, myTextView.Text.Length) / metrics.Density);
    // and finally formating based of if the text fits (again, specific)
    if (textLength > limit)
    {
        myTextView.Text = myTextView.Text.Substring(0, myTextView.Text.IndexOf("-"));
    }
