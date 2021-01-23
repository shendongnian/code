    Image<Bgr, Byte> img_live = Live_Mat.ToImage<Bgr, Byte>();
                for (int i = 0; i < Live_Mat.Height; i++)
                {
                    for (int j = 0; j < Live_Mat.Width; j++)
                    {
                        float blue = img_live.Data[i, j, 0];
                        float green = img_live.Data[i, j, 1];
                        float red = img_live.Data[i, j, 2];
    
                        double sum = red + blue + green;
                        double r = red / sum;
                        double g = green / sum;
                        double b = blue / sum;
    
                        if (sum == 0)
                        {
                            r = 0;
                            g = 0;
                            b = 0;
                        }
    
    
                        img_live.Data[i, j, 0] = System.Convert.ToByte(Math.Round((b * AWB_rgb_mult), 0));
                        img_live.Data[i, j, 1] = System.Convert.ToByte(Math.Round((g * AWB_rgb_mult), 0));
                        img_live.Data[i, j, 2] = System.Convert.ToByte(Math.Round((r * AWB_rgb_mult), 0));
                }
            
