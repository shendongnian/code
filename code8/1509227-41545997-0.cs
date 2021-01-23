    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = canvas.transform.position.z;
            Vector3 mousePosTrans = Camera.main.ScreenToWorldPoint(mousePos);
            RaycastHit2D rayHit = Physics2D.Raycast(mousePosTrans, Vector2.zero);
    
    
            if (rayHit.collider.CompareTag("ball"))
            {
                Debug.Log("Raycast hit ball tag");
    
                Destroy(rayHit.collider.gameObject);
            }
        }
    }
