    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows;
    using System.Windows.Forms;
    using System.Windows.Threading;
    using Application = System.Windows.Forms.Application;
    using Size = System.Drawing.Size;
    
    public static class PictureHelper 
    {
    	public static BitmapImage GetImage(object obj)
    	{
    		try
    		{
    			if (obj == null || string.IsNullOrEmpty(obj.ToString())) return new BitmapImage();
    			
    			#region Picture
    
    			byte[] data = (byte[])obj;
    
    			MemoryStream strm = new MemoryStream();
    
    			strm.Write(data, 0, data.Length);
    
    			strm.Position = 0;
    
    			Image img = Image.FromStream(strm);
    
    			BitmapImage bi = new BitmapImage();
    
    			bi.BeginInit();
    
    			MemoryStream ms = new MemoryStream();
    
    			img.Save(ms, ImageFormat.Bmp);
    
    			ms.Seek(0, SeekOrigin.Begin);
    
    			bi.StreamSource = ms;
    
    			bi.EndInit();
    
    			return bi;
    
    			#endregion
    		}
    		catch
    		{
    			return new BitmapImage();
    		}
    	}
    		
    	public static string PathReturner(ref string name)
            {
                string filepath = "";
                OpenFileDialog openFileDialog = new OpenFileDialog();
                
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = @"Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.gif;*.png;*.jpg";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = @"Please select an image file to upload.";
                
                MiniWindow miniWindow = new MiniWindow();
                miniWindow.Show();
    
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filepath = openFileDialog.FileName;
                    name = openFileDialog.SafeFileName;
                }
    
                miniWindow.Close();
                miniWindow.Dispose();
                return filepath;
            }
    
            public static string Encryptor(this string safeName)
            {
                string extension = Path.GetExtension(safeName);
    
                string newFileName = String.Format(@"{0}{1}{2}", Guid.NewGuid(), DateTime.Now.ToString("MMddyyyy(HHmmssfff)"), extension);
                newFileName = newFileName.Replace("(", "").Replace(")", "");
                return newFileName;
            }
    
    
            public static Bitmap ByteToBitmap(this byte[] blob)
            {
                MemoryStream mStream = new MemoryStream();
                byte[] pData = blob;
                mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                Bitmap bm = new Bitmap(mStream, false);
                mStream.Dispose();
                return bm;
                
            }
    
            public static byte[] BitmapToByte(this Image img)
            {
                byte[] byteArray = new byte[0];
                using (MemoryStream stream = new MemoryStream())
                {
                    img.Save(stream, ImageFormat.Png);
                    stream.Close();
    
                    byteArray = stream.ToArray();
                }
                return byteArray;
            }
    }
