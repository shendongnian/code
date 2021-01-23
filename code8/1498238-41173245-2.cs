       public void OnPagePrint(object sender, PrintPageEventArgs e)
       {
            var availableWidth = 220;
            var printAreaSize = DrawReceipt(availableWidth, e.Graphics, GetReceiptContent());
            e.PageSettings.PaperSize = new PaperSize("CustomPaperSize", (int)printAreaSize.Width + 10, (int)printAreaSize.Height);
        }
    
        public SizeF DrawReceipt(float availableWidth, Graphics graphics, StringBuilder sb)
        {
            var printText = new PrintText(sb.ToString(), new Font("Consolas", 8));
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
