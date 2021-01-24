     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
     RayCastHit rayHit;
            if (Physics.Raycast(ray, out rayHit))
            {
               Vector3 position = rayHit.point;
               position.z = 0f;
               Instantiate(yourGameObject, position, Quaternion.Identity);
            }
