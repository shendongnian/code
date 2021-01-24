    void Update()
    {
        if (Input.touchCount == 1)
        {
            // Trigger place kitten function when single touch ended.
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Ended)
            {
                //Make sure we are not over the UI
                if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                {
                    Debug.Log("Clicked outside the UI");
                    PlaceKitten(t.position);
                }
            }
        }
    }
