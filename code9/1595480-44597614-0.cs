    protected override void OnPaint(PaintEventArgs e) {
      e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      e.Graphics.TranslateTransform(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
      e.Graphics.FillEllipse(Brushes.Red, new Rectangle(-3, -3, 6, 6));
    }
