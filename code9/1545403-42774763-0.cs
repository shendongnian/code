    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                //Check for white path
                if (hit.collider.CompareTag("whitepath"))
                {
                    navAgent.destination = hit.point;
                    navAgent.Resume();
                }
            }
        }
    }
