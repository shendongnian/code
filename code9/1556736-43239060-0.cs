    public async Task<WriteableBitmap> ToWriteableBitmap()
        {
            WriteableBitmap writeableBitmap = new WriteableBitmap(width, height);
            byte[] expanded = new byte[pixels.Length * 4];
            int j = 0;
            for (int i = 0; i< pixels.Length; i++)
            {
                expanded[j++] = pixels[i];
                expanded[j++]= pixels[i];
                expanded[j++] = pixels[i];
                expanded[j++] = 255; //Alpha
            }
            using (Stream stream = writeableBitmap.PixelBuffer.AsStream())
            {
                await stream.WriteAsync(expanded, 0, expanded.Length);
            }
            return writeableBitmap;
        }
