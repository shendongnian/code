    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
     #if UNITY_EDITOR
            if (EditorApplication.isPlaying)
            {
                EditorApplication.isPlaying = false;
            }
    #else 
            Application.Quit();
    #endif
            }
