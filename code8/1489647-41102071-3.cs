        private List<Color> GetAllColors() {
            var list = new List<Color>();
            var colorType = typeof(Color);
            var propInfos = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (var propInfo in propInfos) {
                var color = Color.FromName(propInfo.Name);
                list.Add(color);
            }
            return list;
        }
        // closed match in RGB space
        private int ClosestColor2(List<Color> colors, Color target) {
            var colorDiffs = colors.Select(n => ColorDiff(n, target)).Min(n => n);
            return colors.FindIndex(n => ColorDiff(n, target) == colorDiffs);
        }
        // distance in RGB space
        private static int ColorDiff(Color c1, Color c2) {
            return (int) Math.Sqrt((c1.R - c2.R)*(c1.R - c2.R)
                                   + (c1.G - c2.G)*(c1.G - c2.G)
                                   + (c1.B - c2.B)*(c1.B - c2.B));
        }
        public static Bitmap ResizeImage(Image image, int width, int height) {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var graphics = Graphics.FromImage(destImage)) {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (var wrapMode = new ImageAttributes()) {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }
