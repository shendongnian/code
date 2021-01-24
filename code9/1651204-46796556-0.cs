    IEnumerator CaptureScreenshot(string filename, ScreenshotFormat screenshotFormat)
    {
        //Wait for end of frame
        yield return new WaitForEndOfFrame();
    
        Texture2D screenImage = new Texture2D(Screen.width, Screen.height);
        //Get Image from screen
        screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenImage.Apply();
    
        string filePath = Path.Combine(Application.persistentDataPath, "images");
        byte[] imageBytes = null;
    
        //Convert to png/jpeg/exr
        if (screenshotFormat == ScreenshotFormat.PNG)
        {
            filePath = Path.Combine(filePath, filename + ".png");
            createDir(filePath);
            imageBytes = screenImage.EncodeToPNG();
        }
        else if (screenshotFormat == ScreenshotFormat.JPEG)
        {
            filePath = Path.Combine(filePath, filename + ".jpeg");
            createDir(filePath);
            imageBytes = screenImage.EncodeToJPG();
        }
        else if (screenshotFormat == ScreenshotFormat.EXR)
        {
            filePath = Path.Combine(filePath, filename + ".exr");
            createDir(filePath);
            imageBytes = screenImage.EncodeToEXR();
        }
    
        //Save image to file
        System.IO.File.WriteAllBytes(filePath, imageBytes);
        Debug.Log("Saved Data to: " + filePath.Replace("/", "\\"));
    }
    
    void createDir(string dir)
    {
        //Create Directory if it does not exist
        if (!Directory.Exists(Path.GetDirectoryName(dir)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(dir));
        }
    }
    
    public enum ScreenshotFormat
    {
        PNG, JPEG, EXR
    }
