    void OnGUI()
    {
        if (showInfos)
        {
            var pt = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            if (pt.z > 0) //or < 0, no idea.
            {
                Rect r = new Rect(pt.x + 25, Camera.main.pixelHeight - pt.y + 25, 75f, 75f);
                GUI.Label(r, gameObject.transform.root.name);
            }
        }
    }
