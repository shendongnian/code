    if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
    {
        xDeg -= Input.GetAxis("Mouse X") * speed * friction;
        yDeg += Input.GetAxis("Mouse Y") * speed * friction;
        fromRotation = boneToRotate.rotation;
        toRotation = Quaternion.Euler(yDeg, xDeg, 0);
        Debug.Log("Mouse Freedom");
    }
    boneToRotate.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * lerpSpeed);
