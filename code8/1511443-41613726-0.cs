    const int BUTTON_SIZE = 40;
    int W = ParentPanel.Width / BUTTON_SIZE;
    int H = ParentPanel.Height / BUTTON_SIZE;
    
    for (int x = 0; x < W; x++ )
    {
        for(int y = 0; y < H; y++)
        {
            Button btn = new Button();
            btn.Name = "button_" + x.ToString() + "_" + y.ToString();
            btn.Size = new Size(BUTTON_SIZE, BUTTON_SIZE);
            btn.Location = new Point(BUTTON_SIZE * x, BUTTON_SIZE * y);
            ParentPanel.Controls.Add(btn);
        }
    }
