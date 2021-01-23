    //  Calculate the height of one line of text
    var oneLineHeight = float.MinValue;
    using(Graphics g = this.ultraGrid1.CreateGraphics())
    {
        oneLineHeight = g.MeasureString("Jj", this.ultraGrid1.Font, int.MaxValue, StringFormat.GenericTypographic).Height;
    
    }
    
    // Set the row selectors' style and the row's height
    if(e.Cell.Column.Layout.Override.RowSelectorStyle == Infragistics.Win.HeaderStyle.Default)
    {
        e.Cell.Column.Layout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
    
        //  Add 4 to add some padding
        e.Cell.Row.Height = (int)(oneLineHeight * 20 + 4);
    }
    else
    {
        e.Cell.Column.Layout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Default;
    
        //  Add 4 to add some padding
        e.Cell.Row.Height = (int)(oneLineHeight * 4 + 4);
    }
