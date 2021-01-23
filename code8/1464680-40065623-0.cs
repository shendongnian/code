    protected virtual void Update()
    {
        if (Input.touchCount >= 1)
        {
            if (Input.touches[0].phase == TouchPhase.Stationary)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    touchedObject = hit.transform.gameObject;
    
    
                    touchableGameObject touchScript = touchedObject.GetComponent<touchableGameObject>();
                    if (touchScript != null)
                    {
                        touchScript.Touched();
                    }
    
                    print(touchedObject.name);
                }
                else
                {
                    print("GetMouseButtonDown on nothing");
                }
            }
        }
    }
