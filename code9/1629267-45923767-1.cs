    Vector3 lastDragPosition;
    
    void Update()
    {
    	UpdateDrag();
    }
    
    void UpdateDrag()
    {
    	if (Input.GetMouseButtonDown(2))
    		lastDragPosition = Input.mousePosition;
    	if (Input.GetMouseButton(2))
    	{
    		var delta = lastDragPosition - Input.mousePosition;
    		transform.Translate(delta * Time.deltaTime * 0.25f);
    		lastDragPosition = Input.mousePosition;
    	}
    }
