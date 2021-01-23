        private WriteableBitmap GetSignatureBitmapFull()
        {
            var bytes = ConvertInkCanvasToByteArray();
            if (bytes != null)
            {
                var width = (int)cvsSignature.ActualWidth;
                var height = (int)cvsSignature.ActualHeight;
                var bmp = new WriteableBitmap(width, height);
                using (var stream = bmp.PixelBuffer.AsStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                    return bmp;
                }
            }
            else
                return null;
        }
        private async Task<WriteableBitmap> GetSignatureBitmapFullAsync()
        {
            var bytes = ConvertInkCanvasToByteArray();
            if (bytes != null)
            {
                var width = (int)cvsSignature.ActualWidth;
                var height = (int)cvsSignature.ActualHeight;
                var bmp = new WriteableBitmap(width, height);
                using (var stream = bmp.PixelBuffer.AsStream())
                {
                    await stream.WriteAsync(bytes, 0, bytes.Length);
                    return bmp;
                }
            }
            else
                return null;
        }
