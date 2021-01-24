    private void Table1Requirements()
        {
            int maxColumns = 6;
            this.table1LayoutPanelPrime.CellPaint += new TableLayoutCellPaintEventHandler(tableLayoutPaint(maxColumns));
    
        }
    
       Action<object,TableLayoutCellPaintEventArgs> tableLayoutPaint(int columns)
        return (sender, e) => 
        {
            for (int i = 0; i < columns; i++)
            {
                if (e.Row == 0 && e.Column == i)
                {
                    Graphics g = e.Graphics;
                    Rectangle r = e.CellBounds;
                    g.FillRectangle(Brushes.LightGray, r);
                }
            }
        }
