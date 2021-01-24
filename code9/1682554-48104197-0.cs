    void DrawScene(Graphics g)
    {
        // Clear the screen
        g.Clear(Color.Gray);
        if (f == 1)
            fn = new Font("Times New Roman", st);
        else if (f == 2)
            fn = new Font("Times New Roman", st);
        else if (f == 3)
            s = s.Replace("LL", " L");
        // Draw whatever string is in s with the current font 
        g.DrawString(s, fn, b, x, y);
    }
