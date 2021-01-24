		public static Bitmap ToGrayscale(Bitmap bmp) {
			var result = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format8bppIndexed);
			BitmapData data = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
			// Copy the bytes from the image into a byte array
			byte[] bytes = new byte[data.Height * data.Stride];
			Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
			for (int y = 0; y < bmp.Height; y++) {
				for (int x = 0; x < bmp.Width; x++) {
					var c = bmp.GetPixel(x, y);
					var rgb = (byte)((c.R + c.G + c.B) / 3);
					bytes[x * data.Stride + y] = rgb;
				}
			}
			// Copy the bytes from the byte array into the image
			Marshal.Copy(bytes, 0, data.Scan0, bytes.Length);
			result.UnlockBits(data);
			return result;
		}
