    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.Clear(richTextBox1.BackColor);
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.DrawRtfText(richTextBox1.Rtf,  panel1.ClientRectangle);            
    }
