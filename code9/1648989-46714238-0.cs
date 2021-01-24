    public class CustomDataGridViewCheckBoxColumn: DataGridViewCheckBoxColumn
    {
        public CustomDataGridViewColumn()
        {
            this.CellTemplate = new CustomDataGridViewCheckBoxCell();
        }
    }
    public class CustomDataGridViewCheckBoxCell: DataGridViewCheckBoxCell
    {
        protected override void Paint(Graphics graphics,
                                    Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
                                    DataGridViewElementStates elementState, object value,
                                    object formattedValue, string errorText,
                                    DataGridViewCellStyle cellStyle,
                                    DataGridViewAdvancedBorderStyle advancedBorderStyle,
                                    DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                elementState, value, formattedValue, errorText, cellStyle,
                advancedBorderStyle, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
            var val = (bool?)formattedValue;
            var img = val.HasValue && val.Value ? Properties.Resources.Checked : Properties.Resources.UnChecked;
            var w = img.Width;
            var h = img.Height;
            var x = cellBounds.Left + (cellBounds.Width - w) / 2;
            var y = cellBounds.Top + (cellBounds.Height - h) / 2;
            graphics.DrawImage(img, new Rectangle(x, y, w, h));
        }
    }
