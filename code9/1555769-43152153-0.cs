    void Update()
    {
        if (Input.touchCount == 1)
        {
            //Trigger placepictureframe function when single touch ended.
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Ended)
            {
                //Make sure that pointer is not over UI before calling  PlacePictureFrame
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    PlacePictureFrame(t.position);
                }
            }
        }
    }
