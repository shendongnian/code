    public Bitmap CropToContent(Bitmap oldBmp)
        {
            Rectangle currentRect = new Rectangle();
            bool IsFirstOne = true;
            // Get a base color
            for (int y = 0; y < oldBmp.Height; y++)
            {
                for (int x = 0; x < oldBmp.Width; x++)
                {
                    Color debug = oldBmp.GetPixel(x, y);
                    if (oldBmp.GetPixel(x, y) != Color.FromArgb(255, 255, 255, 255))
                    {
                        // We need to interpret this!
                        // Check if it is the first one!
                        if (IsFirstOne)
                        {
                            currentRect.X = x;
                            currentRect.Y = y;
                            currentRect.Width = 1;
                            currentRect.Height = 1;
                            IsFirstOne = false;
                        }
                        else
                        {
                            if (!currentRect.Contains(new Point(x, y)))
                            {
                                // This will run if this is out of the current rectangle
                                if (x > (currentRect.X + currentRect.Width)) currentRect.Width = x - currentRect.X;
                                if (x < (currentRect.X))
                                {
                                    // Move the rectangle over there and extend it's width to make the right the same!
                                    int oldRectLeft = currentRect.Left;
                                    currentRect.X = x;
                                    currentRect.Width += oldRectLeft - x;
                                }
                                if (y > (currentRect.Y + currentRect.Height)) currentRect.Height = y - currentRect.Y;
                                if (y < (currentRect.Y + currentRect.Height))
                                {
                                    int oldRectTop = currentRect.Top;
                                    currentRect.Y = y;
                                    currentRect.Height += oldRectTop - y;
                                }
                            }
                        }
                    }
                }
            }
            return CropImage(oldBmp, currentRect.X, currentRect.Y, currentRect.Width, currentRect.Height);
        }
