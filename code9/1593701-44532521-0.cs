    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    
        RaycastHit[] hit = Physics.RaycastAll(ray);
    
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].collider != null)
            {
                print(hit[i].transform.gameObject.name);
            }
        }
    }
