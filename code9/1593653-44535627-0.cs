           using System.IO;
           using System.Windows.Media.Imaging;
 
			 public class JXrLib
			{
				public static void JxrToBmp(string source, string target)
				{
					Stream imageStreamSource = new FileStream(source, FileMode.Open, FileAccess.Read, FileShare.Read);
					WmpBitmapDecoder decoder = new WmpBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
					BitmapSource bitmapSource = decoder.Frames[0];
					var encoder = new BmpBitmapEncoder(); ;
					encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
					using (var stream = new FileStream(target, FileMode.Create))
					{
						encoder.Save(stream);
					}
				}
			}
