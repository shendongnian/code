    public static byte[] ConvertImageToByteArray(UIImage Picture) {
        byte [] image = null;
    	try {
    		using (NSData imageData = Picture.Image.AsJPEG (0.5f)) { // Here you can set compression %, 0 = no compression, 1 = max compression, or  the other way around, I'm not sure
    		image = new byte [imageData.Length];
    		Marshal.Copy (imageData.Bytes, image, 0, Convert.ToInt32 (imageData.Length));
    	} catch (Exception e) {
    			Console.WriteLine ("Error @ Picture Byte Conversion: " + e.Message);
    	}
        return image;
    }
