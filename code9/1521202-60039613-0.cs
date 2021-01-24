     void OnPreCull()
    {
        GetComponent<Camera>().ResetWorldToCameraMatrix();
        GetComponent<Camera>().ResetProjectionMatrix();
        GetComponent<Camera>().projectionMatrix = GetComponent<Camera>().projectionMatrix * Matrix4x4.Scale(new Vector3(1, -1, 1));
    }
    void OnPreRender()
    {
        GL.invertCulling = true;
    }
    void OnPostRender()
    {
        GL.invertCulling = false;
    }
