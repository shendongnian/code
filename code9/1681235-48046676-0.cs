    void Update()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began) // when screen is touched...
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector3.forward, out hit)) // ...cast a ray...
            {
                if (hit.collider.tag == "sphere") //...and check if ray hits a sphere
                {
                    selectedObject = hit.collider.gameObject;
                }
            }
        }
        // add touch controls here and apply to selectedObject for movement
    }
