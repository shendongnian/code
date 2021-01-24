     public GameObject OtherModel;   // new model that you want to replace with kitty
     GameObject myRef;               // Reference for the object that is already in scene
    
        void PlaceKitten(Vector2 touchPosition)
        {
            // Find the plane.
            Camera cam = Camera.main;
            Vector3 planeCenter;
            Plane plane;
            if (!m_pointCloud.FindPlane(cam, touchPosition, out planeCenter, out plane))
            {
                Debug.Log("cannot find plane.");
                return;
            }
    
            // Place kitten on the surface, and make it always face the camera.
            if (Vector3.Angle(plane.normal, Vector3.up) < 30.0f)
            {
                Vector3 up = plane.normal;
                Vector3 right = Vector3.Cross(plane.normal, cam.transform.forward).normalized;
                Vector3 forward = Vector3.Cross(right, plane.normal).normalized;
    
                // Check whether we have already placed something or not
                if (myRef != null)
                {
                    Transform temp = myRef.transform;
                    Destroy(myRef);
                    myRef = Instantiate(OtherModel, temp.position, temp.rotation);
                }
                else
                {
                    myRef = Instantiate(m_kitten, planeCenter, Quaternion.LookRotation(forward, up));
                }
            }
            else
            {
                Debug.Log("surface is too steep for kitten to stand on.");
            }
        }
