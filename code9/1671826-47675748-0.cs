    // Make sure to include this at the top
    using System.Drawing.Imaging;
    /// <summary> 
    /// Saves an image as a jpeg image, with the given quality 
    /// </summary> 
    /// <param name="path"> Path to which the image would be saved. </param> 
    /// <param name="quality"> An integer from 0 to 100, with 100 being the highest quality. </param> 
    public static void SaveJpeg (string path, Image img, int quality) 
    { 
        if (quality<0  ||  quality>100) 
            throw new ArgumentOutOfRangeException("quality must be between 0 and 100."); 
    
         // Encoder parameter for image quality 
         EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, quality); 
         // JPEG image codec 
         ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg"); 
         EncoderParameters encoderParams = new EncoderParameters(1); 
         encoderParams.Param[0] = qualityParam; 
         img.Save(path, jpegCodec, encoderParams); 
    } 
    
    /// <summary> 
    /// Returns the image codec with the given mime type 
    /// </summary> 
    private static ImageCodecInfo GetEncoderInfo(string mimeType) 
    { 
         // Get image codecs for all image formats 
         ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders(); 
    
         // Find the correct image codec 
         for(int i=0; i<codecs.Length; i++) 
             if(codecs[i].MimeType == mimeType) 
                 return codecs[i]; 
    
         return null; 
     } 
