    protected static Icon GetTrayIconFromCache(Color statusColor)
    {
        Bitmap bmp = new Bitmap(16,16);                            
        Graphics circleGraphic = Graphics.FromImage(bmp);
        circleGraphic.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        circleGraphic.DrawString("n", new Font("Webdings", 12F, FontStyle.Regular), Brushes.White, -3f, -2f);
        circleGraphic.DrawString("n", new Font("Webdings", 9F, FontStyle.Regular), new SolidBrush(statusColor), 0f, -1f);
        Icon ico = Icon.FromHandle((bmp).GetHicon());
        return ico;
    }
