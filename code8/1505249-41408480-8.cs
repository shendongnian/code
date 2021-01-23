    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        e.DrawBackground();
        if (e.Index >= 0 && e.Index < Items.Count) {
            var item = (MyItemType)Items[e.Index];
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Center;
            var textRect = e.Bounds;
            textRect.X += 35;
            textRect.Width -= 35;
            using (var textBrush = new SolidBrush(e.ForeColor)) {
                e.Graphics.DrawString(item.Text, Font, textBrush, textRect, stringFormat);
            }
            Image img = item.GetThumbnail();
            if (img != null) {
                e.Graphics.DrawImage(img, 1, 1);
            }
        }
        e.DrawFocusRectangle();
    }
