    /// <summary>
    /// Image loading toolset class which corrects the bug that prevents paletted PNG images with transparency from being loaded as paletted.
    /// </summary>
    public class BitmapLoader
    {
        private static Byte[] PNG_IDENTIFIER = {0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A};
        /// <summary>
        /// Loads an image, checks if it is a PNG containing palette transparency, and if so, ensures it loads correctly.
        /// The theory can be found at http://www.libpng.org/pub/png/book/chapter08.html
        /// </summary>
        /// <param name="data">File data to load</param>
        /// <returns>The loaded image</returns>
        public static Bitmap LoadBitmap(Byte[] data)
        {
            Int32 colors;
            return LoadBitmap(data, out colors);
        }
        /// <summary>
        /// Loads an image, checks if it is a PNG containing palette transparency, and if so, ensures it loads correctly.
        /// The theory can be found at http://www.libpng.org/pub/png/book/chapter08.html
        /// </summary>
        /// <param name="data">File data to load</param>
        /// <param name="paletteLength">Palette length in the original image. The palette format of .net is not adjustable in size, so it'll be the max size. This value can be used to adjust that.</param>
        /// <returns>The loaded image</returns>
        public static Bitmap LoadBitmap(Byte[] data, out Int32 paletteLength)
        {
            Bitmap loadedImage;
            if (data.Length > PNG_IDENTIFIER.Length && data.Take(PNG_IDENTIFIER.Length).SequenceEqual(PNG_IDENTIFIER))
            {
                Byte[] transparencyData = null;
                // Check if it contains a palette.
                // I'm sure it can be looked up in the header somehow, but meh.
                Int32 plteOffset = FindChunk(data, "PLTE");
                if (plteOffset != -1)
                {
                    // Check if it contains a palette transparency chunk.
                    Int32 trnsOffset = FindChunk(data, "tRNS");
                    if (trnsOffset != -1)
                    {
                        // Get chunk
                        Int32 trnsLength = GetChunkDataLength(data, trnsOffset);
                        transparencyData = new Byte[trnsLength];
                        Array.Copy(data, trnsOffset + 8, transparencyData, 0, trnsLength);
                        // filter out the palette alpha chunk, make new data array
                        Byte[] data2 = new Byte[data.Length - (trnsLength + 12)];
                        Array.Copy(data, 0, data2, 0, trnsOffset);
                        Int32 trnsEnd = trnsOffset + trnsLength + 12;
                        Array.Copy(data, trnsEnd, data2, trnsOffset, data.Length - trnsEnd);
                        data = data2;
                    }
                }
                // Open a Stream and decode a PNG image
                using (MemoryStream imageStreamSource = new MemoryStream(data))
                {
                    PngBitmapDecoder decoder = new PngBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                    BitmapSource bitmapSource = decoder.Frames[0];
                    Int32 width = bitmapSource.PixelWidth;
                    Int32 height = bitmapSource.PixelHeight;
                    Int32 stride = ImageUtils.GetMinimumStride(width, bitmapSource.Format.BitsPerPixel);
                    Byte[] pixel = new Byte[height * stride];
                    bitmapSource.CopyPixels(pixel, stride, 0);
                    WriteableBitmap myBitmap = new WriteableBitmap(width, height, 96, 96, bitmapSource.Format, bitmapSource.Palette);
                    myBitmap.WritePixels(new Int32Rect(0, 0, width, height), pixel, stride, 0);
                    // Convert WPF BitmapSource to GDI+ Bitmap
                    Bitmap newBitmap = BitmapFromSource(myBitmap);
                    System.Drawing.Color[] colpal = newBitmap.Palette.Entries;
                    Boolean hasTransparency = false;
                    if (colpal.Length != 0 && transparencyData != null)
                    {
                        for (Int32 i = 0; i < colpal.Length; i++)
                        {
                            if (i >= transparencyData.Length)
                                break;
                            System.Drawing.Color col = colpal[i];
                            colpal[i] = System.Drawing.Color.FromArgb(transparencyData[i], col.R, col.G, col.B);
                            if (!hasTransparency)
                                hasTransparency = transparencyData[i] == 0;
                        }
                    }
                    paletteLength = colpal.Length;
                    if (hasTransparency)
                    {
                        Byte[] imageData = ImageUtils.GetImageData(newBitmap, out stride);
                        return ImageUtils.BuildImage(imageData, newBitmap.Width, newBitmap.Height, stride, newBitmap.PixelFormat, colpal, System.Drawing.Color.Empty);
                    }
                    return newBitmap;
                }
            }
            using (MemoryStream ms = new MemoryStream(data))
            {
                loadedImage = new Bitmap(ms);
                ms.Close();
                paletteLength = loadedImage.Palette.Entries.Length;
            }
            return ImageUtils.CloneImage(loadedImage);
        }
        /// <summary>
        /// Finds the start of a png chunk. This assumes the image is already identified as PNG.
        /// It does not go over the first 8 bytes, but starts at the start of the header chunk.
        /// </summary>
        /// <param name="data">The bytes of the png image</param>
        /// <param name="chunkName">The name of the chunk to find.</param>
        /// <returns>The index of the start of the png chunk, or -1 if the chunk was not found.</returns>
        private static Int32 FindChunk(Byte[] data, String chunkName)
        {
            if (chunkName.Length != 4 )
                throw new ArgumentException("Chunk must be 4 characters!", "chunkName");
            Byte[] chunkNamebytes = Encoding.ASCII.GetBytes(chunkName);
            if (chunkNamebytes.Length != 4)
                throw new ArgumentException("Chunk must be 4 characters!", "chunkName");
            Int32 offset = PNG_IDENTIFIER.Length;
            Int32 end = data.Length;
            Byte[] testBytes = new Byte[4];
            // continue until either the end is reached, or there is not enough space behind it for reading a new header
            while (offset < end && offset + 8 < end)
            {
                Array.Copy(data, offset + 4, testBytes, 0, 4);
                // Alternative for more visual debugging:
                //String currentChunk = Encoding.ASCII.GetString(testBytes);
                //if (chunkName.Equals(currentChunk))
                //    return offset;
                if (chunkNamebytes.SequenceEqual(testBytes))
                    return offset;
                Int32 chunkLength = GetChunkDataLength(data, offset);
                // chunk size + chunk header + chunk checksum = 12 bytes.
                offset += 12 + chunkLength;
            }
            return -1;
        }
        private static Int32 GetChunkDataLength(Byte[] data, Int32 offset)
        {
            if (offset + 4 > data.Length)
                throw new IndexOutOfRangeException("Bad chunk size in png image.");
            // Don't want to use BitConverter; then you have to check platform endianness and all that mess.
            Int32 length = data[offset + 3] + (data[offset + 2] << 8) + (data[offset + 1] << 16) + (data[offset] << 24);
            if (length < 0)
                throw new IndexOutOfRangeException("Bad chunk size in png image.");
            return length;
        }
    }
