    void OnImageLoad(string path,Texture2D tex, ImageOrientation orientation)
    {
        GameObject.Find("Cube").GetComponent<Renderer>().material.mainTexture = tex;
        log += "\nImage Saved to gallery, loaded :" + path + ", orientation : " + orientation;
        myTexture = tex;
    }
