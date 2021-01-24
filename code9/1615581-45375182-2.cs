    float Vector3 oldpos;
    void Update ()
    {
        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                oldpos = t.position; //get initial touch position
            }
            if (t.phase == TouchPhase.Moved)
            {
                // check if the distance between stored position and current touch position is greater than "2"
                if (Mathf.Abs(Vector3.Distance(oldpos, t.position)) > 2f)
                {
                    PlaceKitten(t.position);
                    oldpos = t.position; // store position for next distance check
                }
            }
        }
    }
