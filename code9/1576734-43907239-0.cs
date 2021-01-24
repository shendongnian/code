		static void Main()
		{
			var srcBitmap = new Bitmap(@"d:\Temp\SAE5\Resources\TestFiles\rose.jpg");
			var destBitmap = CropBitmap(srcBitmap, new Rectangle(10, 20, 50, 25));
			destBitmap.Save(@"d:\Temp\tst.png");
		}
		static Bitmap CropBitmap(Bitmap sourceBitmap, Rectangle rect)
		{
			// Add code to check and adjust rect to be inside sourceBitmap
			var sourceBitmapData = sourceBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
			var destBitmap = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
			var destBitmapData = destBitmap.LockBits(new Rectangle(0, 0, rect.Width, rect.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
			var pixels = new int[rect.Width * rect.Height];
			System.Runtime.InteropServices.Marshal.Copy(sourceBitmapData.Scan0, pixels, 0, pixels.Length);
			System.Runtime.InteropServices.Marshal.Copy(pixels, 0, destBitmapData.Scan0, pixels.Length);
			sourceBitmap.UnlockBits(sourceBitmapData);
			destBitmap.UnlockBits(destBitmapData);
			return destBitmap;
		}
