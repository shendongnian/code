            Image imageChipsetName = new System.Drawing.Bitmap(photoWidth, photoHeight);
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Center;
            strFormat.LineAlignment = StringAlignment.Center;
            Font strFontA = new Font("Tahoma", 14, FontStyle.Underline);//Font used by stringA
            Graphics graphics = Graphics.FromImage(imageChipsetName);
            graphics.DrawString(stringA + "\n",
                                strFont_A, Brushes.Black,
                                new RectangleF(0, 0, photoWidth, photoHeight), strFormat);
            SizeF stringSizeA = new SizeF();
            stringSizeA = Graphics.MeasureString(stringA, strFont_A);//Measuring the size of stringA
            graphics.DrawString(stringB,
                                new Font("Tahoma", 14), Brushes.Black,
                                new RectangleF(0, stringSizeA.Height, photoWidth, photoHeight - stringSizeA.Height), strFormat);
