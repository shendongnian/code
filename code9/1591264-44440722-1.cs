    int rows = 7; //Will come from database
    int cols = 3; //Will come from database
    int colWidth;
    int rowHeight;
    PictureBox pbox;
    Random rnd = new Random();
    colWidth = 100 / cols;
    if (100 % cols != 0)
        colWidth--;
    rowHeight = 100 / rows;
    if (100 % rows != 0)
        rowHeight--;
    tabLP.Controls.Clear();
    tabLP.ColumnStyles.Clear();
    tabLP.RowStyles.Clear();
    tabLP.ColumnCount = cols;
    for (int i = 0; i < rows; i++)
    {
        tabLP.RowStyles.Add(new RowStyle(SizeType.Percent, rowHeight));                
        for (int j = 0; j < cols; j++)
        {
            tabLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, colWidth));
                    
            if (rnd.NextDouble() > 0.5 )
            {
                pbox = new PictureBox() { Image = Properties.Resources.red_X};
            }
            else
            {
                pbox = new PictureBox() { Image = Properties.Resources.checkbox_green };
            }
            pbox.Dock = DockStyle.Fill;
            pbox.SizeMode = PictureBoxSizeMode.StretchImage;
            tabLP.Controls.Add(pbox, j, i);
        }
    }
