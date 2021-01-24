    private void ReadTiff()
    {
        Tiff tiff = Tiff.Open("myfile.tif", "r");
        if (tiff == null)
            return;
        //Get the image size
        int imageWidth = tiff.GetField(TiffTag.IMAGEWIDTH)[0].ToInt();
        int imageHeight = tiff.GetField(TiffTag.IMAGELENGTH)[0].ToInt();
        //Get the tile size
        int tileWidth = tiff.GetField(TiffTag.TILEWIDTH)[0].ToInt();
        int tileHeight = tiff.GetField(TiffTag.TILELENGTH)[0].ToInt();
        int tileSize = tiff.TileSize();
        //Pixel depth
        int depth = tileSize / (tileWidth * tileHeight);
        byte[] buffer = new byte[tileSize];
        for (int y = 0; y < imageHeight; y += tileHeight)
        {
            for (int x = 0; x < imageWidth; x += tileWidth)
            {
                //Read the value and store to the buffer
                tiff.ReadTile(buffer, 0, x, y, 0, 0);
                for (int kx = 0; kx < tileWidth; kx++)
                {
                    for (int ky = 0; ky < tileHeight; ky++)
                    {
                        //Calculate the index in the buffer
                        int startIndex = (kx + tileWidth * ky) * depth;
                        if (startIndex >= buffer.Length)
                            continue;
                        //Calculate pixel index
                        int pixelX = x + kx;
                        int pixelY = y + ky;
                        if (pixelX >= imageWidth || pixelY >= imageHeight)
                            continue;
                        //Get the value for the target pixel
                        double value = BitConverter.ToSingle(buffer, startIndex);
                    }
                }
            }
        }
        tiff.Close();
    }
