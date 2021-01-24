    class CustomToolTip : ToolTip
        {
            public CustomToolTip()
            {
                this.OwnerDraw = true;
                this.Popup += new PopupEventHandler(this.OnPopup);
                this.Draw += new DrawToolTipEventHandler(this.OnDraw);
            }
            string m_EndSpecialText;
            Color m_EndSpecialTextColor =Color.Red;
            public Color EndSpecialTextColor
            {
                get { return m_EndSpecialTextColor; }
                set { m_EndSpecialTextColor = value; }
            }
            public string EndSpecialText
            {
                get { return m_EndSpecialText; }
                set { m_EndSpecialText = value; }
            }
            private void OnPopup(object sender, PopupEventArgs e) // use this event to set the size of the tool tip
            {
                e.ToolTipSize = new Size(200, 100);
            }
            private void OnDraw(object sender, DrawToolTipEventArgs e) // use this event to customise the tool tip
            {
                Graphics g = e.Graphics;
                LinearGradientBrush b = new LinearGradientBrush(e.Bounds,
                    Color.GreenYellow, Color.MintCream, 45f);
                g.FillRectangle(b, e.Bounds);
                g.DrawRectangle(new Pen(Brushes.Red, 1), new Rectangle(e.Bounds.X, e.Bounds.Y,
                    e.Bounds.Width - 1, e.Bounds.Height - 1));
                //g.DrawString(e.ToolTipText, new Font(e.Font, FontStyle.Bold), Brushes.Silver,
                //    new PointF(e.Bounds.X + 6, e.Bounds.Y + 6)); // shadow layer
                g.DrawString(e.ToolTipText, new Font(e.Font, FontStyle.Bold), Brushes.Black,
                    new PointF(e.Bounds.X + 5, e.Bounds.Y + 5)); // top layer
                SolidBrush brush = new SolidBrush(EndSpecialTextColor);
                g.DrawString(EndSpecialText, new Font(e.Font, FontStyle.Bold), brush,
                    new PointF(e.Bounds.X + 5, e.Bounds.Bottom - 15)); // top layer
                brush.Dispose();
                b.Dispose();
            }
        }
