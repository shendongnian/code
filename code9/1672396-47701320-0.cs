    private bool IsLastColumn = false;
    private bool IsMouseDown = false;
    private int MouseLocationX = 0;
    
    private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
    {
       int _LastColumnIndex = dataGridView1.Columns.Count - 1;
       //Check if the mousedown is contained in last column boundaries
       //In the middle of it because clicking the divider of the row before
       //the last may be seen as inside the last too.
       Point _Location = new Point(e.X - (dataGridView1.Columns[_LastColumnIndex].Width / 2), e.Y);
       if (dataGridView1.GetColumnDisplayRectangle(_LastColumnIndex, true).Contains(_Location))
       {
          //Store a positive checks and the current mouse position
          this.IsLastColumn = true;
          this.IsMouseDown = true;
          this.MouseLocationX = e.Location.X;
       }
    }
    
    private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
    {
       //If it's the last column and the left mouse button is pressed...
       if ((this.IsLastColumn == true) && (this.IsMouseDown == true) && (e.Button == System.Windows.Forms.MouseButtons.Left))
       {
          //... calculate the offset of the movement.
          //You'll have to play with it a bit, though
          int _ColumnWidth = dataGridView1.Columns[dataGridView1.Columns.Count - 1].Width;
          int _ColumnWidthOffset = _ColumnWidth + (e.X - this.MouseLocationX) > 0 ? (e.X - this.MouseLocationX) : 1;
          //If mouse pointer reaches the limit of the clientarea...
          if ((_ColumnWidthOffset > -1) && (e.X >= dataGridView1.ClientSize.Width - 1))
          {
             //...resize the column and move the scrollbar offset
             dataGridView1.HorizontalScrollingOffset = dataGridView1.ClientSize.Width + _ColumnWidth + _ColumnWidthOffset;
             dataGridView1.Columns[dataGridView1.Columns.Count - 1].Width = _ColumnWidth + _ColumnWidthOffset;
          }
       }
    }
    
    private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
    {
          this.IsMouseDown = false;
          this.IsLastColumn = false;
    }
