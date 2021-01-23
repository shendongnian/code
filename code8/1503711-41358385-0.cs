    public Texture2D img1;
    bool showImage = true;
    
    void OnGUI()
    {
        if (showImage)
        {
            GUILayout.Label(img1);
        }
    
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                CancelInvoke(methodName: "ChangeImage");
                showImage = false;
            }
        }
    }
