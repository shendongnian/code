    class BigCheckedListBox : CheckedListBox
    {
        public BigCheckedListBox()
        {
            ForeColor = Color.Turquoise;
            Font = new Font("Segoe UI", 12f);
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            var b = e.Bounds;
            var state = GetItemChecked(e.Index) ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal;
            Size glyphSize = CheckBoxRenderer.GetGlyphSize(e.Graphics, state);
            int checkPad = (b.Height - glyphSize.Height) / 2;
            var pt = new Point(b.X + checkPad, b.Y + checkPad);
            Rectangle rect = new Rectangle(pt, new Size(20, 20));
            e.Graphics.DrawRectangle(Pens.Green, rect);//This is for Checkbox rectangle
            //This is for drawing string text
            using (SolidBrush brush = new SolidBrush(ForeColor))
                e.Graphics.DrawString(this.Items[e.Index].ToString(), Font, brush, pt.X + 27f, pt.Y); 
 
            if (state == CheckBoxState.CheckedNormal)
            {
                using (SolidBrush brush = new SolidBrush(ForeColor))
                using (Font wing = new Font("Wingdings", 17f, FontStyle.Bold))
                    e.Graphics.DrawString("ü", wing, brush, pt.X-4, pt.Y-1); //This is For tick mark
            }
        }
    }
