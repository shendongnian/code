    public Image[] image;
    void activateImage(string imageName, bool enable)
    {
        for (int i = 0; i < image.Length; i++)
        {
            if (image[i].name == imageName)
            {
                image[i].enabled = enable;//Good for performace
                // OR
                //image[i].gameObject.SetActive(enable);
            }
        }
    }
