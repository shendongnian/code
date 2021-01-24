    void Main()
    {
        var bmp = new Bitmap(320, 320, PixelFormat.Format32bppArgb);
        using (var g = Graphics.FromImage(bmp))
        {
            g.Clear(Color.Gray);
     
            var str = @"BAS2016=PTR=E30BAS2010=(S20)$W30$PTO2016=N5W20N5(W20N10)(S10W20)S5W5S5E10N10(E15N5)(S5E15)S10E25$W25N10(W15N5)(S5W15)S10W10S15BAS2020=S15PTO2013=S5E20S5(E20S10)(N10E20)N5E5N5W10S10(W15S5)(N5W15)N10W25$E25S10(E15S5)(N5E15)N10E10N15W65$E65N15$.";
            var font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular, GraphicsUnit.Point);           
            int lineIndex=0;
            double lineHeight = font.Height;
     
            while (str.Length > 0)
            {
                float lineLength = 0;
                int currentChar = 1;
     
                while (lineLength < bmp.Width - 5 && currentChar <= str.Length)
                {
                    string line= str.Substring(0, currentChar);
                    lineLength = g.MeasureString(line, font).Width;
                    currentChar++;
                }
                g.DrawString(str.Substring(0,currentChar-1),font,Brushes.Black,0,(float)Math.Ceiling(lineIndex*lineHeight),StringFormat.GenericDefault);
               
                str = str.Substring(currentChar-1);
                lineIndex++;
                currentChar=1;               
            }
        }
        bmp.Dump();
    }
