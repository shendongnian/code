    public RawImage imageDisp;
    public Texture2D img1;
    
    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                CancelInvoke(methodName: "ChangeImage");
                imageDisp.enabled = false;
            }
        }
    }
