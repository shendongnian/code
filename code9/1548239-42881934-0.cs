    void Update()
    {
        //Check if mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
    
            //Get ray from mouse postion
            Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
    
            //Raycast and check if any object is hit
            if (Physics.Raycast(rayCast, out hit, jumpMaxDistance))
            {
                //Check which tag is hit
                if (hit.collider.CompareTag("RichPoint"))
                {
                    print(hit.collider.transform.position);
                }
            }
        }
    }
