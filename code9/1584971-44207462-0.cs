    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Texture2D proc = new Texture2D(src.width, src.height);
        proc.ReadPixels(new Rect(0, 0, src.width, src.height), 0, 0);
        proc.Apply();
        Color[] line = proc.GetPixels(src.width / 2, 0, 1, src.height);
        Debug.Log(line[0] + " : "  + line[line.Length-1]);
        Graphics.Blit(proc, dest);
    }
