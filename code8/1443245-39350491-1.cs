    private void panel1_Scroll(object sender, ScrollEventArgs e)
    {
        for (int y = 0; y < 40; y++)
        {
            // try to find a control..
            Label lbl = (Label)panel1.GetChildAtPoint(new Point(20, y));
            // we habe found a Label!
            if (lbl != null) 
            {
                 ...
                break;
            }
        }
    }
