    //You need to draw both Headers...
    private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
       e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
       //Let the system draw these headers, nothing to do here
       e.DrawDefault = true;
    }
    
    //...  and SubItems
    private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
       //If this is the column where the image is shown, draw it
       if (e.ColumnIndex == 3)
       {
          //Position the image in the middle of its Column
          //This will be re-calculated when the Column is resized
          int _XLocation = (e.SubItem.Bounds.X + 
                           (e.SubItem.Bounds.Width / 2) - 
                           (e.SubItem.Bounds.Height / 2));
          //Draw the Image resized to the Height of the row
          e.Graphics.DrawImage(_image, new Rectangle(_XLocation, e.SubItem.Bounds.Y, e.SubItem.Bounds.Height, e.SubItem.Bounds.Height));
       }
       //Draw the other columns using their pre-defined values
       e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
       e.Graphics.DrawString(e.SubItem.Text, 
                             e.SubItem.Font, 
                             new SolidBrush(e.SubItem.ForeColor), 
                             e.SubItem.Bounds.Location.X, 
                             e.SubItem.Bounds.Location.Y);
    }
