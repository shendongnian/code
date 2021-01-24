    //get the image from the file they gave us, resize it, and rotate it if needed
    	OnlineImage onlineImageHelper = new OnlineImage(Context.Request.Files(0).InputStream);
    	byte[] pictureLarger = onlineImageHelper.StraightenedThumbnail(new Size(180, 180));
    	byte[] pictureSmaller = onlineImageHelper.StraightenedThumbnail(new Size(80, 80));
    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    
    public class OnlineImage
    {
    	public OnlineImage()
    	{
    		throw new NotImplementedException();
    	}
    
    	public OnlineImage(Stream imageStream)
    	{
    		_ImageFromUser = Image.FromStream(imageStream);
    		RotateImage();
    	}
    
    	private Image _ImageFromUser;
    	private Image _RotatedImage;
    	private Image _ResizedAndRotatedImage;
    
    	private void RotateImage()
    	{
    		if (_RotatedImage == null && _ImageFromUser != null && _ImageFromUser.PropertyIdList != null && _ImageFromUser.PropertyIdList.Contains(0x112)) {
    			int rotationValue = _ImageFromUser.GetPropertyItem(0x112).Value(0);
    			switch (rotationValue) {
    				case 1:
    					// landscape, do nothing
    					break; // TODO: might not be correct. Was : Exit Select
    
    					break;
    				case 8:
    					// rotated 90 right
    					// de-rotate:
    					_ImageFromUser.RotateFlip(rotateFlipType: RotateFlipType.Rotate270FlipNone);
    					break; // TODO: might not be correct. Was : Exit Select
    
    					break;
    				case 3:
    					// bottoms up
    					_ImageFromUser.RotateFlip(rotateFlipType: RotateFlipType.Rotate180FlipNone);
    					break; // TODO: might not be correct. Was : Exit Select
    
    					break;
    				case 6:
    					// rotated 90 left
    					_ImageFromUser.RotateFlip(rotateFlipType: RotateFlipType.Rotate90FlipNone);
    					break; // TODO: might not be correct. Was : Exit Select
    
    					break;
    			}
    			_RotatedImage = _ImageFromUser;
    		}
    	}
    
    	private void ResizeImage(Size size, bool preserveAspectRatio = true)
    	{
    		int newWidth = 0;
    		int newHeight = 0;
    		if (preserveAspectRatio) {
    			int originalWidth = _ImageFromUser.Width;
    			int originalHeight = _ImageFromUser.Height;
    			float percentWidth = Convert.ToSingle(size.Width) / Convert.ToSingle(originalWidth);
    			float percentHeight = Convert.ToSingle(size.Height) / Convert.ToSingle(originalHeight);
    			float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
    			newWidth = Convert.ToInt32(originalWidth * percent);
    			newHeight = Convert.ToInt32(originalHeight * percent);
    		} else {
    			newWidth = size.Width;
    			newHeight = size.Height;
    		}
    
    		_ResizedAndRotatedImage = new Bitmap(newWidth, newHeight);
    
    		using (Graphics graphicsHandle = Graphics.FromImage(_ResizedAndRotatedImage)) {
    			graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
    			graphicsHandle.DrawImage(_ImageFromUser, 0, 0, newWidth, newHeight);
    		}
    	}
    
    	public byte[] StraightenedThumbnail(Size resizedDimensions)
    	{
    		byte[] result = null;
    		MemoryStream msPicture = new MemoryStream();
    		ResizeImage(resizedDimensions);
    		if (_ResizedAndRotatedImage != null) {
    			_ResizedAndRotatedImage.Save(msPicture, ImageFormat.Png);
    			result = msPicture.ToArray();
    			return result;
    		}
    
    		return null;
    	}
    }
