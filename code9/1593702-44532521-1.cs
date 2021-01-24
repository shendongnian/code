    //Detect only 10. Can be changed to anything
    RaycastHit[] results = new RaycastHit[10];
    
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    
        int hitCount = Physics.RaycastNonAlloc(ray, results);
    
        for (int i = 0; i < hitCount; i++)
        {
            if (results[i].collider != null)
            {
                print(results[i].transform.gameObject.name);
            }
        }
    }
