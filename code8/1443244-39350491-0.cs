    private void panel1_Scroll(object sender, ScrollEventArgs e)
    {
        for (int y = 0; y < 40; y++)
        {
            Label lbl = (Label)panel1.GetChildAtPoint(new Point(20, y));
            if (lbl != null) 
            {
                 ...
                break;
            }
        }
    }
