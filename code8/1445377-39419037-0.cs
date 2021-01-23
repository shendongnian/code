    void LerpQuat(QuatLerpInput rotThis, float time, float leftBoundary, float rightBoundary)
    {
        /*
         * we want to rotate forward, then backward the same amount
         * to avoid spinning. we store the given value to both of these.
        */
        Transform stuffToRot = rotThis.godRayGO.transform;
      
        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;
        switch (rotThis.rotState)
        {
            case (QuatLerpInput.RotationStates.rotAway):
                rotThis.deltaRot = Random.Range(leftBoundary, rightBoundary);
                Quaternion destination = new Quaternion(rotThis.idleQuat.x, rotThis.idleQuat.y, rotThis.deltaRot, 1.0f);
                rotThis.deltaQuat = destination;
                rotThis.deltaEulerAngle = Vector3.forward * rotThis.deltaRot;               
                StartCoroutine(RotateMe(rotThis, rotThis.idleQuat, rotThis.deltaEulerAngle, initiateAlphaSwap));
                break;
            case (QuatLerpInput.RotationStates.setBack):
                StartCoroutine(RotateMe(rotThis, rotThis.deltaQuat,-1.0f * rotThis.deltaEulerAngle, initiateAlphaSwap));
                break;
        }
    }
    IEnumerator RotateMe(QuatLerpInput whatToRotate,Quaternion fromWhere,Vector3 byAngles, float inTime)
    {
        Quaternion fromAngle = fromWhere;
        Quaternion toAngle = Quaternion.Euler(whatToRotate.godRayGO.transform.eulerAngles + byAngles);
        toAngle = new Quaternion(toAngle.x, toAngle.y, toAngle.z, 1.0f);
        if(whatToRotate.rotState == QuatLerpInput.RotationStates.setBack)
        {
            fromAngle = new Quaternion(whatToRotate.RotEndPos.x, whatToRotate.RotEndPos.y, whatToRotate.RotEndPos.z, 1.0f);
            toAngle = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
        }
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / inTime)
        {
            whatToRotate.godRayGO.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
            yield return null;
        }
        if(whatToRotate.rotState == QuatLerpInput.RotationStates.rotAway)
        {
            whatToRotate.rotState = QuatLerpInput.RotationStates.setBack;
            whatToRotate.RotEndPos = new Vector3(toAngle.x, toAngle.y, toAngle.z);
        }
        else
        {
            whatToRotate.rotState = QuatLerpInput.RotationStates.rotAway;
        }
        
    }
