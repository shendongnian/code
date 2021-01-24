    private void Form1_Load(object sender, EventArgs e)
    {
        comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
        comboBox1.DrawItem += new DrawItemEventHandler(comboBox1_DrawItem);
    }
    private void comboBox1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
    {
        try
        {
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Define the default color of the brush as black.
            Brush myBrush = Brushes.Black;
                
            // Draw the current item text based on the current Font 
            // and the custom brush settings.
            e.Graphics.DrawString(comboBox1.Items[e.Index].ToString(), e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }
        catch (Exception ex)
        {
        }
    }
