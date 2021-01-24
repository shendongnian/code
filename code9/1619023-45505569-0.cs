        Camera cam = Camera.Main;
        void Update()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 touchPos = Input.GetTouch(0).Position;
                transform.position = cam.ScreenToWorldPoint(new Vector3(touchPos.x, touchPos.y, 0));
            }
        }
