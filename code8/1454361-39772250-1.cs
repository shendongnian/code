    public class MyDataGridTextBoxColumn : DataGridTextBoxColumn
    {
        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source,
           int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            if (rowNum == 1) /*Specific row index*/
            {
                var value = this.PropertyDescriptor.GetValue(source.List[rowNum]);
                var text = string.Format("{0}", value);
                Rectangle rect = bounds;
                using (var format = new StringFormat())
                {
                    if (alignToRight)
                        format.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
                    format.Alignment = (this.Alignment == HorizontalAlignment.Left) ?
                        StringAlignment.Near :
                        ((this.Alignment == HorizontalAlignment.Center) ?
                        StringAlignment.Center : StringAlignment.Far);
                    format.FormatFlags |= StringFormatFlags.NoWrap;
                    g.FillRectangle(backBrush, rect);
                    rect.Offset(0, 2);
                    rect.Height -= 2;
                    var font = new Font(this.DataGridTableStyle.DataGrid.Font, FontStyle.Bold);
                    g.DrawString(text, font, foreBrush, rect, format);
                }
            }
            else
                base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
        }
    }
