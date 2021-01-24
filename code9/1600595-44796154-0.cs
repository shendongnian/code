    public void ConvertHtmlToImage()
    {
       Bitmap m_Bitmap = new Bitmap(400, 600);
       PointF point = new PointF(0, 0);
       SizeF maxSize = new System.Drawing.SizeF(500, 500);
       HtmlRenderer.HtmlRender.Render(Graphics.FromImage(m_Bitmap),
                                               "<html><body><p>This is a just a html code</p>"
                                               + "<p>This is another html line</p></body>",
                                                point, maxSize);
    
       m_Bitmap.Save(@"C:\Test.png", ImageFormat.Png);
    }
