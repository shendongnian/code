        private Color borderColor;
        private int entered;
        public TUserControlGroupBox() {
            this.borderColor = SystemColors.ControlDark;
        }
        public Font _Font {
            get { return this.Font; }
            set { this.Font = value; }
        }
        public Color BorderColor {
            get { return this.borderColor; }
            set { this.borderColor = value; }
        }
        public BorderState Border {
            set {
                switch (value) {
                    case BorderState.Unselected:
                        this.BorderColor = Color.LightGray;
                        break;
                    case BorderState.Selected:
                        this.BorderColor = Color.Black;
                        break;
                    case BorderState.SelectedFirst:
                        this.BorderColor = SystemColors.ControlDark;
                        break;
                }
                this.Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e) {
            Size tSize = TextRenderer.MeasureText(this.Text, this.Font);
            Rectangle borderRect = e.ClipRectangle;
            borderRect.Y += tSize.Height / 2;
            borderRect.Height -= tSize.Height / 2;
            if ((this.BorderColor == Color.Black || this.borderColor == SystemColors.ControlDark) && this.entered == 1) {
                ControlPaint.DrawBorder(e.Graphics, borderRect,
                    this.borderColor, 4, ButtonBorderStyle.Solid,
                    this.borderColor, 4, ButtonBorderStyle.Solid,
                    this.borderColor, 4, ButtonBorderStyle.Solid,
                    this.borderColor, 4, ButtonBorderStyle.Solid);
            } else {
                ControlPaint.DrawBorder(e.Graphics, borderRect, this.borderColor, ButtonBorderStyle.Solid);
            }
            Rectangle textRect = e.ClipRectangle;
            textRect.X += 6;
            textRect.Width = tSize.Width;
            textRect.Height = tSize.Height;
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), textRect);
            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), textRect);
        }
        protected override void OnMouseClick(MouseEventArgs e) {
            this.entered = 1;
            this.Invalidate();
            base.OnMouseClick(e);
        }
