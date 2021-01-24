    private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
        if (e.ColumnIndex != myColumnIndex)
        {
            e.DrawDefault = true; // tell the ListView to draw this header
            return;
        }
        e.DrawBackground();
        
        // draw your text as you did in your code
        // except the FillRectangle since the background is
        // now already drawn
    } 
