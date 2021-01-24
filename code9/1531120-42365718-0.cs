        if (GestureManager.Instance.IsNavigating &&
        HandsManager.Instance.FocusedGameObject == gameObject)
            {
                    //here we get the movement direction and set it in movement.
                    if (GestureManager.Instance.NavigationPosition.y > 0)
                    {
                        movement = 2;
                    }
                    else if (GestureManager.Instance.NavigationPosition.y < 0)
                    {
                        movement = -2;
                    }
                //the first part is false if we reach higher then maxdistance and the movement is going up
                //the second part is false if we reach the lower distance and the movement is going down.
                if ((!(distance > maxdistance.x) || movement < 0) && ((!(distance < mindistance.x) || movement > 0)))
                    {
                        //here we add the movement to the distance so we know if it gets closer or further
                        distance += movement;
                        //here we rotate
                        totransform.Rotate(new Vector3(movement, 0, 0));
                    }
            }
