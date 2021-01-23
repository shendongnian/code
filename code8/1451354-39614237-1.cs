    Dictionary<string, Image> image = new Dictionary<string, Image>();
    void activateImage(string imageName, bool enable)
    {
        if (image.ContainsKey(imageName))
        {
            image[imageName].enabled = enable;//Good for performace
            // OR
            //image[imageName].gameObject.SetActive(enable);
        }
    }
