    public void UpdateCanvas()
    {
        Image img;
        using (var bmpTemp = new Bitmap(graphPath))
        {
            img = new Bitmap(bmpTemp);
        }
        pbCanvas.Image = img;  
    }
