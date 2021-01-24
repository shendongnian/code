    private bool firstClick = false;
    private Vector3 oldMousePosition;
    private Vector3 newMousePosition;
    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!firstClick)
            {
                firstClick = true;
                oldMousePosition = Input.mousePosition();
            }
            else
            {
                newMousePosition = Input.mousePosition();
                Vector3 offset = oldMousePosition - newMousePosition;
                oldMousePosition = newMousePosition();
                transform.localPosition += offset;
            }
        }
        if (Input.GetMouseButtonUp(0))
           firstClick = false;
    }
