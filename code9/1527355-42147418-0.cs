     private int _maxColumns;
     public ValResults()
        {
            InitializeComponent();
            this.Table1Requirements();
            SetColumnCount(); 
        }
    private void SetColumnCount(){
        _maxColumns= 6;
    }
    
    void tableLayoutPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            for (int i = 0; i < _maxColumns; i++)
            {
                if (e.Row == 0 && e.Column == i)
            {
                    Graphics g = e.Graphics;
                    Rectangle r = e.CellBounds;
                    g.FillRectangle(Brushes.LightGray, r);
            }
            }
        }
