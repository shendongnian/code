    private Ray ray;
    private RaycastHit hit;
    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
         
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.name == "YourGameObject")
                {
                    // Do your stuff on click
                }
            }
        }
    }
