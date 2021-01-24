    List<Vector2> touchMovedPositions = new List<Vector2>();
    if(Input.touchCount > 0)
    {
        foreach((Touch touch in Input.touches) 
        {
            if(touch.phase == TouchPhase.Moved)
            {
                touchMovedPositions.Add(touch.position);
            }
        }
     }
