    class SpecialButton: Button
    {
        private Point ClickOrigin;
        private const int ClickMaxDistance = 5;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            ClickOrigin = System.Windows.Forms.Cursor.Position;
            base.OnMouseDown(e);
        }
        protected override void OnClick(EventArgs e)
        {
            Point p = System.Windows.Forms.Cursor.Position;
            if(Math.Abs(p.X - ClickOrigin.X) < ClickMaxDistance &&
                Math.Abs(p.Y - ClickOrigin.Y) < ClickMaxDistance)
            base.OnClick(e);
        }
    }
