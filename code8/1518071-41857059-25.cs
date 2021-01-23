    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    namespace ConnectedComponentLabeling
    {
        public class CCL
        {
            private Bitmap _input;
            private int[,] _board;
            public IDictionary<Rectangle, Bitmap> Process(Bitmap input)
            {
                _input = input;
                _board = new int[_input.Width, _input.Height];
                Dictionary<int, List<Pixel>> patterns = Find();
                var images = new Dictionary<Rectangle, Bitmap>();
                foreach (KeyValuePair<int, List<Pixel>> pattern in patterns)
                {
                    using (Bitmap bmp = CreateBitmap(pattern.Value))
                    {
                        images.Add(GetBounds(pattern.Value), (Bitmap)bmp.Clone());
                    }
                }
                return images;
            }
            protected virtual bool CheckIsBackGround(Pixel currentPixel)
            {
                return currentPixel.color.A == 255 && currentPixel.color.R == 255 && currentPixel.color.G == 255 && currentPixel.color.B == 255;
            }
            private unsafe Dictionary<int, List<Pixel>> Find()
            {
                int labelCount = 1;
                var allLabels = new Dictionary<int, Label>();
                BitmapData imageData = _input.LockBits(new Rectangle(0, 0, _input.Width, _input.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                try
                {
                    int bytesPerPixel = 3;
                    byte* scan0 = (byte*)imageData.Scan0.ToPointer();
                    int stride = imageData.Stride;
                    for (int i = 0; i < _input.Height; i++)
                    {
                        byte* row = scan0 + (i * stride);
                        for (int j = 0; j < _input.Width; j++)
                        {
                            int bIndex = j * bytesPerPixel;
                            int gIndex = bIndex + 1;
                            int rIndex = bIndex + 2;
                            byte pixelR = row[rIndex];
                            byte pixelG = row[gIndex];
                            byte pixelB = row[bIndex];
                            Pixel currentPixel = new Pixel(new Point(j, i), Color.FromArgb(pixelR, pixelG, pixelB));
                            if (CheckIsBackGround(currentPixel))
                            {
                                continue;
                            }
                            IEnumerable<int> neighboringLabels = GetNeighboringLabels(currentPixel);
                            int currentLabel;
                            if (!neighboringLabels.Any())
                            {
                                currentLabel = labelCount;
                                allLabels.Add(currentLabel, new Label(currentLabel));
                                labelCount++;
                            }
                            else
                            {
                                currentLabel = neighboringLabels.Min(n => allLabels[n].GetRoot().Name);
                                Label root = allLabels[currentLabel].GetRoot();
                                foreach (var neighbor in neighboringLabels)
                                {
                                    if (root.Name != allLabels[neighbor].GetRoot().Name)
                                    {
                                        allLabels[neighbor].Join(allLabels[currentLabel]);
                                    }
                                }
                            }
                            _board[j, i] = currentLabel;
                        }
                    }
                }
                finally
                {
                    _input.UnlockBits(imageData);
                }
                Dictionary<int, List<Pixel>> patterns = AggregatePatterns(allLabels);
                patterns = RemoveIntrusions(patterns, _input.Width, _input.Height);
                return patterns;
            }
            private Dictionary<int, List<Pixel>> RemoveIntrusions(Dictionary<int, List<Pixel>> patterns, int width, int height)
            {
                var patternsCleaned = new Dictionary<int, List<Pixel>>();
                foreach (var pattern in patterns)
                {
                    bool bad = false;
                    foreach (Pixel item in pattern.Value)
                    {
                        //Horiz
                        if (item.Position.X == 0)
                            bad = true;
                        else if (item.Position.Y == width - 1)
                            bad = true;
                        //Vert
                        else if (item.Position.Y == 0)
                            bad = true;
                        else if (item.Position.Y == height - 1)
                            bad = true;
                    }
                    if (!bad)
                        patternsCleaned.Add(pattern.Key, pattern.Value);
                }
                return patternsCleaned;
            }
            private IEnumerable<int> GetNeighboringLabels(Pixel pix)
            {
                var neighboringLabels = new List<int>();
                for (int i = pix.Position.Y - 1; i <= pix.Position.Y + 2 && i < _input.Height - 1; i++)
                {
                    for (int j = pix.Position.X - 1; j <= pix.Position.X + 2 && j < _input.Width - 1; j++)
                    {
                        if (i > -1 && j > -1 && _board[j, i] != 0)
                        {
                            neighboringLabels.Add(_board[j, i]);
                        }
                    }
                }
                return neighboringLabels;
            }
            private Dictionary<int, List<Pixel>> AggregatePatterns(Dictionary<int, Label> allLabels)
            {
                var patterns = new Dictionary<int, List<Pixel>>();
                for (int i = 0; i < _input.Height; i++)
                {
                    for (int j = 0; j < _input.Width; j++)
                    {
                        int patternNumber = _board[j, i];
                        if (patternNumber != 0)
                        {
                            patternNumber = allLabels[patternNumber].GetRoot().Name;
                            if (!patterns.ContainsKey(patternNumber))
                            {
                                patterns[patternNumber] = new List<Pixel>();
                            }
                            patterns[patternNumber].Add(new Pixel(new Point(j, i), Color.Black));
                        }
                    }
                }
                return patterns;
            }
            private unsafe Bitmap CreateBitmap(List<Pixel> pattern)
            {
                int minX = pattern.Min(p => p.Position.X);
                int maxX = pattern.Max(p => p.Position.X);
                int minY = pattern.Min(p => p.Position.Y);
                int maxY = pattern.Max(p => p.Position.Y);
                int width = maxX + 1 - minX;
                int height = maxY + 1 - minY;
                Bitmap bmp = DrawFilledRectangle(width, height);
                BitmapData imageData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                try
                {
                    byte* scan0 = (byte*)imageData.Scan0.ToPointer();
                    int stride = imageData.Stride;
                    foreach (Pixel pix in pattern)
                    {
                        scan0[((pix.Position.X - minX) * 3) + (pix.Position.Y - minY) * stride] = pix.color.B;
                        scan0[((pix.Position.X - minX) * 3) + (pix.Position.Y - minY) * stride + 1] = pix.color.G;
                        scan0[((pix.Position.X - minX) * 3) + (pix.Position.Y - minY) * stride + 2] = pix.color.R;
                    }
                }
                finally
                {
                    bmp.UnlockBits(imageData);
                }
                return bmp;
            }
            private Bitmap DrawFilledRectangle(int x, int y)
            {
                Bitmap bmp = new Bitmap(x, y);
                using (Graphics graph = Graphics.FromImage(bmp))
                {
                    Rectangle ImageSize = new Rectangle(0, 0, x, y);
                    graph.FillRectangle(Brushes.White, ImageSize);
                }
                return bmp;
            }
            private Rectangle GetBounds(List<Pixel> pattern)
            {
                var points = pattern.Select(x => x.Position);
                var x_query = points.Select(p => p.X);
                int xmin = x_query.Min();
                int xmax = x_query.Max();
                var y_query = points.Select(p => p.Y);
                int ymin = y_query.Min();
                int ymax = y_query.Max();
                return new Rectangle(xmin, ymin, xmax - xmin, ymax - ymin);
            }
        }
    }
