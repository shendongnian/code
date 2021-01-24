    for (int i = 0; i < objectsToRotate.Length; i++)
    {
       if((int)Math.Ceiling(rotationMultiplier) >= 500)
       {
          rotationMultiplier -= 0.1f;
       }
       else
       {
         rotationMultiplier += 0.1f;
       }
       objectsToRotate[i].transform.Rotate(Vector3.forward, Time.deltaTime * rotationMultiplier);
    }
