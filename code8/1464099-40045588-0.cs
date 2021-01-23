    private string GenerateBannerTitle()
        {
            var bitmap = new Bitmap(PhysicalBannerPath);
            RectangleF rectf = new RectangleF(430, 50, 650, 50);
            using (var g = Graphics.FromImage(bitmap))
            {
                using (var arialFont = new Font("Arial", 10))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    g.DrawString("hfsdfdsfds", new Font("courier sans", 100, FontStyle.Bold), Brushes.White, rectf);
                }
            }
            var ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            var arr = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(arr, 0, (int)ms.Length);
            ms.Close();
            var strBase64 = Convert.ToBase64String(arr);
            return strBase64;
        }
