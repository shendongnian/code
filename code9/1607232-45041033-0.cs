        if (Input.touchCount == 1)
        {
            // Trigger place kitten function when single touch ended.
            Touch t = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(t.position);
            RaycastHit hit;
            if(t.phase == TouchPhase.Ended && Physics.Raycast(ray,out hit,100))
            {
                if(hit.collider.tag == "button")
                {
                    //do button stuff
                }
                else
                {
                    PlaceKitten(t.position);
                }
            }
        }
