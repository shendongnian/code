    Panel pnl = this.Controls.OfType<Panel>();
    if(pnl != null)
    {
       DataGridView grid = pnl.Controls.OfType<DataGridView>();
       .... do stuff with the grid
    }
