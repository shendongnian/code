    private void sample()
    {
        int rowIndex = 0;
        int colIndex = 0;
        Dictionary<int[], Image> temp = new Dictionary<int[], Image>();
        int[] rowcol = new int[] { rowIndex, colIndex };
       
        if (!(temp.Where(k => k.Key == rowcol).Count() > 0))
        {
            animatedImage = style.BackgroundImage;
            temp.Add(rowcol, animatedImage);
        }
    }
