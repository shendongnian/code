    void receivePNGScreenShot(byte[] pngArray)
    {
        Debug.Log("Picture taken");
        //Do Something With the Image (Save)
        string path = Application.persistentDataPath + "/CanvasScreenShot.png";
        System.IO.File.WriteAllBytes(path, pngArray);
        Debug.Log(path);
    }
