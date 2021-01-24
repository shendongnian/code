    // Start with 2 to have margins in the top/left
    int cX = 2;
    int cY = 2;
    
    for (int x = 0; x < 8; x++)
    {
        for (int y = 0; y < 8; y++)
        {
            var btn = new Button();
            btn.Location = new Point(cX, cY);
            btn.Size = new Size(32, 32);
            Controls.Add(btn);
            cX += 34;
        }
    
        cY += 34;
        cX = 2;
    }
