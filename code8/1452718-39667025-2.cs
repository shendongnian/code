    public class MyDataGridViewTextBoxCell:DataGridViewTextBoxCell
    {
        protected override Size GetPreferredSize(Graphics graphics, 
            DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize)
        {
            if(cellStyle.WrapMode== DataGridViewTriState.True && this.RowIndex>=0)
            {
                var value= string.Format("{0}", this.FormattedValue);
                using (var g = this.OwningColumn.DataGridView.CreateGraphics())
                {
                    var r =  g.MeasureString(value, cellStyle.Font, this.OwningColumn.Width )
                              .ToSize();
                    r.Width += cellStyle.Padding.Left + cellStyle.Padding.Right;
                    r.Height += cellStyle.Padding.Top + cellStyle.Padding.Bottom;
                    return r;
                }
            }
            else
            {
                return base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
            }
        }
        protected override void Paint(Graphics graphics, Rectangle clipBounds, 
            Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, 
            object value, object formattedValue, string errorText, 
            DataGridViewCellStyle cellStyle, 
            DataGridViewAdvancedBorderStyle advancedBorderStyle, 
            DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, 
                formattedValue, errorText, cellStyle, advancedBorderStyle, 
                paintParts & ~ DataGridViewPaintParts.ContentForeground);
            graphics.DrawString(string.Format("{0}", formattedValue), 
                cellStyle.Font, Brushes.Black, cellBounds);
        }
    }
