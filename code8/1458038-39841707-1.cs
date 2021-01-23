            var pixelReader = GetPixelReader(hdu.MandatoryKeywords.BitsPerPixel);
            var imageBytes = new byte[xAxis * yAxis * sizeof(Int16)];
            using (var outStream = new MemoryStream(imageBytes, writable: true))
            using (var writer = new BinaryWriter(outStream))
            using (var inStream = new MemoryStream(hdu.RawData, writable: false))
            using (var reader = new BinaryReader(inStream, Encoding.ASCII))
                for (var y = 0; y < yAxis; y++)
                    {
                    for (var x = 0; x < xAxis; x++)
                        {
                        writer.Write(pixelReader(reader));
                        }
                    }
            var bitmap = CreateGreyscaleBitmapFromBytes(imageBytes, xAxis, yAxis);
            return bitmap;
