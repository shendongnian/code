     public static WriteableBitmap centerCropImage(WriteableBitmap image)
        {
            
          
            int originalWidth = image.PixelWidth;
            int originalHeight = image.PixelHeight;
            //Getting the new width
            int newWidth = originalWidth > originalHeight? originalHeight : originalWidth;
            //Calculating the cropping points
            int cropStartX, cropStartY;
            if(originalWidth > originalHeight){
	            cropStartX = (originalWidth - newWidth)/2;
	            cropStartY = 0;	
            }
            else{
	            cropStartY = (originalHeight - newWidth)/2;
	            cropStartX = 0;	
            }
            //Then use the following values to get the cropped image
	        var cropped = image.Crop(new Rect(cropStartX, cropStartY, newWidth, newWidth));
            //Then resize the new square image to 250 by 250 px
            var resized = WriteableBitmapExtensions.Resize(cropped, 250, 250, WriteableBitmapExtensions.Interpolation.NearestNeighbor);
            return resized;
        }
