    void Update()
    {
        if (Input.touchCount == 1)
        {
            // Trigger place kitten function when single touch ended.
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Ended)
            {
                //Make sure we are not over the UI
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    Debug.Log("Touched outside the UI");
                    PlaceKitten(t.position);
                }
            }
        }
    }
