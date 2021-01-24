    bool rotating = false;
    
    IEnumerator rotateObject(GameObject objPoint, Vector3 pivot, Vector3 angles, float duration)
    {
        if (rotating)
        {
            yield break;
        }
        rotating = true;
    
        Vector3 beginRotPoint = RotatePointAroundPivot(objPoint.transform.position, pivot, Vector3.zero);
    
        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
    
            float t = counter / duration;
            Vector3 tempAngle = Vector3.Lerp(Vector3.zero, angles, t);
    
            Vector3 tempPivot = RotatePointAroundPivot(beginRotPoint, pivot, tempAngle);
            objPoint.transform.position = tempPivot;
            Debug.Log("Running: " + t);
            yield return null;
        }
        rotating = false;
    }
