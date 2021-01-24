    public static byte[] MakeGrayScaleRev(byte[] source, ref Bitmap bmp,int Hei,int Wid)
            {            
                int bytesPerPixel = 4;   
    
                byte[] bytesBig = new byte[Wid * Hei]; //create array to contain bitmap data with padding
    
                unsafe
                {
    
                    int ic = 0, oc = 0, x = 0;
                    //Convert the pixel to it's luminance using the formula:
                    // L = .299*R + .587*G + .114*B
                    //Note that ic is the input column and oc is the output column                  
                    for (int ind = 0, i = 0; ind < 4 * Hei * Wid; ind += 4, i++)
                    {                        
                        int g = (int)
                                ((source[ind] / 255.0f) *
                                (0.301f * source[ind + 1] +
                                 0.587f * source[ind + 2] +
                                0.114f * source[ind + 3]));
                        bytesBig[i] = (byte)g;
                    }    
                }
                 
                try
                {
                   
                    bmp = new Bitmap(Wid, Hei, PixelFormat.Format8bppIndexed);
    
                    bmp.Palette = GetGrayScalePalette();
    
                    Rectangle dimension = new Rectangle(0, 0, Wid, Hei);
                    BitmapData picData = bmp.LockBits(dimension, ImageLockMode.ReadWrite, bmp.PixelFormat);
    
    
                    IntPtr pixelStartAddress = picData.Scan0;
                    
                    Marshal.Copy(forpictures, 0, pixelStartAddress, forpictures.Length);
    
                    bmp.UnlockBits(picData);
                    
                    return bytesBig;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    
                    return null;
    
                }
    
            }
