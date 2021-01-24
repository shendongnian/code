    listBox.DrawMode = DrawMode.OwnerDrawFixed;
    listBox.DrawItem += new DrawItemEventHandler(listBoxEvent);
    private void listBoxEvent(object sender, 
    System.Windows.Forms.DrawItemEventArgs e)
    {
        // Draw the background of the ListBox control for each item.
        e.DrawBackground();
    }
