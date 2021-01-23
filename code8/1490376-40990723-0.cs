        protected override void OnPaint(PaintEventArgs e) {
            string sample = "abc                       def";
            e.Graphics.DrawString(sample, this.Font, Brushes.Black, PointF.Empty);
            e.Graphics.DrawLine(Pens.Red, trackBar1.Value, 0, trackBar1.Value, 100);
            StringFormat sf = new StringFormat(StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoWrap | StringFormatFlags.LineLimit);
            sf.Trimming = StringTrimming.Character;
            var underscoreWidth = e.Graphics.MeasureString("_", this.Font).Width;
            for (int i = 0; i < sample.Length; i++) {
                var s = sample.Substring(0, i + 1) + "_";
                var size = e.Graphics.MeasureString(s, this.Font).Width - underscoreWidth;
                if (size > trackBar1.Value) {
                    if (s.Length > 0) {
                        var ok = s.Substring(0, s.Length - 2);
                        textBox1.Text = "[" + ok + "]";
                        base.OnPaint(e);
                        return;
                    }
                }
            }
            textBox1.Text = "[" + sample + "]";
            base.OnPaint(e);
        }
