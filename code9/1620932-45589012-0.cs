    bool copyLargeVideoToPersistentDataPath(string videoNameWithExtensionName)
    {
        string path = Path.Combine(Application.streamingAssetsPath, videoNameWithExtensionName);
    
        string persistentPath = Path.Combine(Application.persistentDataPath, "Videos");
        persistentPath = Path.Combine(persistentPath, videoNameWithExtensionName);
    
        bool success = true;
    
        try
        {
            using (FileStream fromFile = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (FileStream toFile = new FileStream(persistentPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    byte[] buffer = new byte[32 * 1024];
                    int bytesRead;
                    while ((bytesRead = fromFile.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        toFile.Write(buffer, 0, bytesRead);
                    }
                    Debug.Log("Done! Saved to Dir: " + persistentPath);
                    Debug.Log(videoNameWithExtensionName + " Successfully Copied Video to " + persistentPath);
                    text.text = videoNameWithExtensionName + " Successfully Copied Video to " + persistentPath;
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(videoNameWithExtensionName + " Failed To Copy Video. Reason: " + e.Message);
            text.text = videoNameWithExtensionName + " Failed To Copy Video. Reason: " + e.Message;
            success = false;
        }
    
        return success;
    }
