            MemoryStream ms = new MemoryStream();
            const int min = 128; // Grey midpoint
            using (var img = Image.Load(ImagePath))
            using (var texture = Image.Load(Texture))
            {
                if (img.Width > texture.Width || img.Height > texture.Height)
                {
                    throw new InvalidOperationException("Image dimensions must be less than or equal to texture dimensions!");
                }
                Image<Rgba32> animated = new Image<Rgba32>(img.Width, img.Height);
                foreach (var Frame in texture.Frames)
                {
                    using (var imageFrame = img.Frames.CloneFrame(0))
                    {
                        Image<Rgba32> currentFrame = imageFrame;
                        for (int y = 0; y < currentFrame.Height; y++)
                        {
                            for (int x = 0; x < currentFrame.Width; x++)
                            {
                                var pixel = currentFrame[x, y];
                                if (pixel.R >= min && pixel.G >= min && pixel.B >= min && pixel.A >= min)
                                {
                                    currentFrame[x, y] = Frame[x, y];
                                }
                            }
                        }
                        animated.Frames.AddFrame(currentFrame.Frames.First());
                    }
                }
                GifEncoder GifEncode = new GifEncoder();
                animated.SaveAsGif(ms);
                return ms;
