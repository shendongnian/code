    bp = new Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height); //Set Screen Size 
    if (bp != null)
    {
        Graphics gr = Graphics.FromImage(bp);
        if (gr != null)
        {
            gr.CopyFromScreen(0, 0, 0, 0, new Size(bp.Width, bp.Height),CopyPixelOperation.SourceCopy);
        }
    }
