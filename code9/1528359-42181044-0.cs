    private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
        if (e.ColumnIndex != myColumnIndex)
        {
            e.DrawDefault = true; // tell the ListView to draw this header
            return;
        }
        e.DrawBackground();
        
        // draw your text in your desired color
    } 
