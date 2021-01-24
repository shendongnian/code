    Rectangle[] myRectangle = new Rectangle[100];
    for(int i = 0; i < 100; i++)
    {
        myRectangle[i] = new Rectangle();
        myRectangle[i].Tag = i;
        myRectangle[i].MouseEnter += MouseEnter;
    }
    private void MouseEnter(object sender, MouseEventArgs e)
    {
        Rectangle rect = sender as Rectangle;
        if (rect == null) return;
        int idx = (int)rect.Tag;
        MessageBox.Show(idx.ToString());
    }
