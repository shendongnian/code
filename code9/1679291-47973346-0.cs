    Vector3 mouseStartPosition;
    Vector3 playerPosOnMouseClick;
    if(Input.GetButtonDown(KeyCode.Mouse0){
        mouseStartPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        playerPosOnMouseClick = transform.position;
    }
    if (moving)
    {
        Vector3 currentMousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector3 newPosition = playerPosOnMouseClick + (mouseStartPosition - currentMousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }
