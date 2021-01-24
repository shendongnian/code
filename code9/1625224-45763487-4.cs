    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.Clear(richTextBox1.BackColor);
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        Padding pad = new Padding(120, 230, 10, 30);  // pick your own numbers!
        Rectangle rect = new Rectangle(pad.Left, pad.Top,
                                       panel1.ClientSize.Width - pad.Horizontal, 
                                       panel1.ClientSize.Height - pad.Vertical);
        e.Graphics.DrawRtfText(this.richTextBox1.Rtf, rect);            
            
    }
