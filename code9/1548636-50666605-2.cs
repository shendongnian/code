    //Used to store RectTransform information so that original RawImage settings can be restored
    public struct RawImageInfo
    {
        public Vector3 anchorPos;
        public Vector2 widthAndHeight;
        public Vector2 anchorMin;
        public Vector2 anchorMax;
        public Vector2 pivot;
        public Vector2 offsetMin;
        public Vector2 offsetMax;
        public Quaternion rot;
        public Vector3 scale;
    }
    RawImageInfo originalImgInfo;
    bool fullSclreen = false;
    void Awake()
    {
        //Get the default RawImage RectTransform settings
        originalImgInfo = GetImageSettings(image);
    }
    void Update()
    {
        //Toggle fullscreen when Space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Toggle
            fullSclreen = !fullSclreen;
            if (fullSclreen)
                StretchImageFullScreen(image, 90);
            else
                ApplyImageSettings(image, originalImgInfo);
        }
        //Restore RawImage default settings when R key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            ApplyImageSettings(image, originalImgInfo);
            fullSclreen = false;
        }
    }
    private void StretchImageFullScreen(RawImage rawImage, int rotAngle = 0)
    {
        RectTransform rectTrfm = rawImage.rectTransform;
        //Get angle and change z-axis
        Vector3 rot = rectTrfm.rotation.eulerAngles;
        rot.z = rotAngle; //Set Z rotation to rotAngle
        rectTrfm.rotation = Quaternion.Euler(rot);
        //Get current angle after changing it
        rot = rectTrfm.rotation.eulerAngles;
        if (Mathf.Approximately(rot.z, 0) || Mathf.Approximately(rot.z, 180))
        {
            rectTrfm.anchoredPosition3D = new Vector3(0, 0, 0);
            //Stretch the Image so that the whole screen is totally covered
            rectTrfm.anchorMin = new Vector2(0, 0);
            rectTrfm.anchorMax = new Vector2(1, 1);
            rectTrfm.pivot = new Vector2(0.5f, 0.5f);
            rectTrfm.offsetMin = Vector2.zero;
            rectTrfm.offsetMax = Vector2.zero;
        }
        else if (Mathf.Approximately(rot.z, -90) || Mathf.Approximately(rot.z, 90)
             || Mathf.Approximately(rot.z, 270))
        {
            //Get the Canvas RectTransform
            RectTransform canvasRectTrfm = rawImage.canvas.GetComponent<RectTransform>();
            float aspRatio = canvasRectTrfm.rect.size.x / canvasRectTrfm.rect.size.y;
            float halfAspRatio = aspRatio / 2.0f;
            float halfAspRatioInvert = (1.0f / aspRatio) / 2.0f;
            rectTrfm.anchorMin = new Vector2(0.5f - halfAspRatioInvert, 0.5f - halfAspRatio);
            rectTrfm.anchorMax = new Vector2(0.5f + halfAspRatioInvert, 0.5f + halfAspRatio);
            rectTrfm.anchoredPosition3D = Vector3.zero;
            rectTrfm.pivot = new Vector2(0.5f, 0.5f);
            rectTrfm.offsetMin = Vector2.zero;
            rectTrfm.offsetMax = Vector2.zero;
        }
    }
    RawImageInfo GetImageSettings(RawImage rawImage)
    {
        RectTransform rectTrfm = rawImage.rectTransform;
        RawImageInfo rawImgInfo = new RawImageInfo();
        //Get settings from RawImage and store as RawImageInfo 
        rawImgInfo.anchorPos = rectTrfm.anchoredPosition3D;
        rawImgInfo.widthAndHeight = rectTrfm.sizeDelta;
        rawImgInfo.anchorMin = rectTrfm.anchorMin;
        rawImgInfo.anchorMax = rectTrfm.anchorMax;
        rawImgInfo.pivot = rectTrfm.pivot;
        rawImgInfo.offsetMin = rectTrfm.offsetMin;
        rawImgInfo.offsetMax = rectTrfm.offsetMax;
        rawImgInfo.rot = rectTrfm.rotation;
        rawImgInfo.scale = rectTrfm.localScale;
        return rawImgInfo;
    }
    private void ApplyImageSettings(RawImage rawImage, RawImageInfo rawImgInfo)
    {
        RectTransform rectTrfm = rawImage.rectTransform;
        //Apply settings from RawImageInfo to RawImage RectTransform
        rectTrfm.anchoredPosition3D = rawImgInfo.anchorPos;
        rectTrfm.sizeDelta = rawImgInfo.widthAndHeight;
        rectTrfm.anchorMin = rawImgInfo.anchorMin;
        rectTrfm.anchorMax = rawImgInfo.anchorMax;
        rectTrfm.pivot = rawImgInfo.pivot;
        rectTrfm.offsetMin = rawImgInfo.offsetMin;
        rectTrfm.offsetMax = rawImgInfo.offsetMax;
        rectTrfm.rotation = rawImgInfo.rot;
        rectTrfm.localScale = rawImgInfo.scale;
    }
