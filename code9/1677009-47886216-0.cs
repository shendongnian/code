    public static bool IsSignatureEmpty(string base64Source)
        {
            Bitmap signatureBM = null;
            try
            {
                byte[] byteBuffer = Convert.FromBase64String(base64Source.Replace("data:image/png;base64,", ""));
                MemoryStream memoryStream = new MemoryStream(byteBuffer);
                memoryStream.Position = 0;
                signatureBM = (Bitmap)Bitmap.FromStream(memoryStream);
                memoryStream.Close();
                memoryStream = null;
                byteBuffer = null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            int width = signatureBM.Width;
            int height = signatureBM.Height;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //Name==0 would equal the color white
                    if (signatureBM.GetPixel(x, y).Name != "0")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
