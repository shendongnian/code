    Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
    
            if (Physics.Raycast(Camera.main.ScreentoWorldPoint(Input.mousePosition), Vector3.forward, out hit))
                Debug.Log("object clicked: " + hit.collider.name));
            else
                Debug.Log("Bad Click, here is no object")
        }
    }
