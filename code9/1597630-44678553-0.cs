    if (Equals(ImageFormat.Png, imageFormatToConvert) || Equals(ImageFormat.Gif, imageFormatToConvert) || Equals(ImageFormat.Jpeg, imageFormatToConvert)
    {
    	if (Equals(ImageFormat.Jpeg, imageFormatToConvert))
    	{
    		ImageCodecInfo[] arrImageCodecInfo = ImageCodecInfo.GetImageEncoders();
    		using (EncoderParameters encoderParameters = new EncoderParameters(1))
    		{
    			encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 90L);
    			bitmap.Save(targetImageFilePath, arrImageCodecInfo[1], encoderParameters);
    		}
    	}
    	else{
    		bitmap.Save(targetImageFilePath, imageFormatToConvert);
    	}
    }
    else
    {
    	throw new Exception($"Convert to <{imageFormatToConvert.ToString()}> from " +
    						$"<{new ImageFormatConverter().ConvertToString(image.RawFormat)}>" +
    						$" image format is not supported now.");
    }
