        void Update ()
        {
            if (Input.touchCount == 1)
            {
                // Trigger place kitten function when single touch moves.
                Touch t = Input.GetTouch(0);
                if (t.phase == TouchPhase.Moved)
                {
                    PlaceKitten(t.position);
                }
            }
        }
