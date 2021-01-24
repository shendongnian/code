            SizeF size;
            using (var graphics = Graphics.FromImage(new Bitmap(1, 1)))
            {
                size = graphics.MeasureString(Text, new Font(FontFamily.ToString(), Convert.ToSingle(FontSize), System.Drawing.FontStyle.Regular, GraphicsUnit.Pixel));
            }
            var mousepos = Mouse.GetPosition(this);
            var textXLocationAtRightmostEdge = (ActualWidth / 2) + (size.Width / 2);
            CaretIndex = mousepos.X >= textXLocationAtRightmostEdge ? Text.Length : GetCharacterIndexFromPoint(mousepos, true);
