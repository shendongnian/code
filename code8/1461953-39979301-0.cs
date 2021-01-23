    Vector3 normalOfHit;
         void Update()
            {
                if (Input.GetMouseButtonDown(0)) //It places cube on left click
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        normalOfHit = hit.normal;
                        normalOfHit = hit.transform.TransformDirection(normalOfHit);
        
                        if(normalOfHit == hit.transform.up)
                        {
                            Debug.Log("Hit top side");
                        }
                        if (normalOfHit ==  -hit.transform.up)
                        {
                            Debug.Log("Hit bottom side");
                        }
                        if (normalOfHit == hit.transform.right)
                        {
                            Debug.Log("Hit right side");
                        }
                        if (normalOfHit == -hit.transform.right)
                        {
                            Debug.Log("Hit left side");
                        }
                        if(normalOfHit == hit.transform.forward)
                        {
                            Debug.Log("Hit front side");
                        }
                        if(normalOfHit == -hit.transform.forward)
                        {
                            Debug.Log("Hit back of object");
                        }
                    }
                }
        }
