    float distance = 100f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMousePressed = true;
            pointsList.RemoveRange(0, pointsList.Count);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isMousePressed = false;
        }
        if (isMousePressed)
        {            
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;
            
             if (Physics.Raycast (ray, out hit, distance)) 
             {
                 if(!pointsList.Contains(hit.point)
                 {
                     pointsList.Add(hit.point); 
                 }           
             }    
        }
    }
