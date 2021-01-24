    void GetPNG()
    {
        // Create a texture the size of the screen, RGB24 format
        int width = Screen.width;
        int height = Screen.height;
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();
        //Create second texture to copy the first texture into minus the background colour. RGBA32 needed for Alpha channel
        Texture2D CroppedTexture = new Texture2D(width, height, TextureFormat.RGBA32, false);
        Color BackGroundCol = new Color();//This is your background colour/s
        //Height of image in pixels
        for(int y=0; y<tex.height; y++){
        	//Width of image in pixels
        	for(int x=0; x<tex.width; x++){
        		Color cPixelColour = tex.GetPixel(x,y);
        		if(cPixelColour != BackGroundCol){
        			CroppedTexture.SetPixel(x,y, cPixelColour); 
        		}else{
        			CroppedTexture.SetPixel(x,y, Color.clear);
        		}
        	}
        }
        // Encode your cropped texture into PNG
        byte[] bytes = CroppedTexture.EncodeToPNG();
        Object.Destroy(CroppedTexture);
        Object.Destroy(tex);
        // For testing purposes, also write to a file in the project folder
        File.WriteAllBytes(Application.dataPath + "/../CroppedImage.png", bytes);
    }
