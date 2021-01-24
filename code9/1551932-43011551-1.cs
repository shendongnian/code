     static int[] getStartX(Bitmap bmp)
            {
                int[] arr = new int[2];
                for (int x = 0; x < bmp.Width - 1; x++)
                {
                    for (int y = 0; y < bmp.Height - 1; y++)
                    {
                         Color color = bmp.GetPixel(x, y);
                         if (color.ToArgb() == Color.Black.ToArgb())
                         {
                             arr[0] = x-1;
                             arr[1] = y;
                             return arr;
                         }
                    }
                }
                return arr;
            }
            static int[] getStartY(Bitmap bmp)
            {
                int[] arr = new int[2];
                for (int x = 0; x < bmp.Height - 1; x++)
                {
                    for (int y = 0; y < bmp.Width - 1; y++)
                    {
                        Color color = bmp.GetPixel(y, x); //mistake
                        if (color.ToArgb() == Color.Black.ToArgb())
                        {
                            arr[0] = y; //mistake
                            arr[1] = x-1; //mistake
                            return arr;
                        }
                    }
                }
                return arr;
            }
            static int[] getEndX(Bitmap bmp)
            
            {
                int[] arr = new int[2];
                for (int x = bmp.Width-1 ;  x >= 0; x--)
                {
                    for (int y = bmp.Height - 1; y >=0 ; y--)
                    {
                        Color color = bmp.GetPixel(x, y);
                        if (color.ToArgb() == Color.Black.ToArgb())
                        {
                            arr[0] = x+1;
                            arr[1] = y;
                            return arr;
                        }
                    }
                }
                return arr;
            }
            static int[] getENdY(Bitmap bmp)
            {
                int[] arr = new int[2];
                for (int x = bmp.Height - 1; x >= 0; x--)
                {
                    for (int y = bmp.Width - 1; y >= 0; y--)
                    {
                        Color color = bmp.GetPixel(y, x); //mistake
                        if (color.ToArgb() == Color.Black.ToArgb())
                        {
                            arr[0] = y; //mistake
                            arr[1] = x+1; //mistake
                            return arr;
                        }
                    }
                }
                return arr;
            }
