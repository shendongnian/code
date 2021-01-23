    public void OnPagePrint(object sender, PrintPageEventArgs e)
    {
        Font font = new Font("Courier New", 10);
        float fontHeight = font.GetHeight();
        e.PageSettings.PaperSize.Width = 229;
        DrawReceipt(e.Graphics, GetReceiptContent());
    }
    public SizeF DrawReceipt(Graphics graphics, StringBuilder sb)
    {
        var printText = new PrintText(sb.ToString(), new Font("Consolas", 8));
        float availableWidth = 220;
        var layoutArea = new SizeF(availableWidth, 0);
        SizeF stringSize = graphics.MeasureString(printText.Text, printText.Font, layoutArea, printText.StringFormat);
        RectangleF rectf = new RectangleF(new PointF(), new SizeF(availableWidth, stringSize.Height));
        graphics.DrawString(printText.Text, printText.Font, Brushes.Black, rectf, printText.StringFormat);
        foreach (var img in images)
        {
            graphics.DrawImage(img.Image, img.Location);
        }
        return stringSize;
    }
