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
