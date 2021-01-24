    public Camera cam;
    Coroutine zoomCoroutine;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //Stop old coroutine
            if (zoomCoroutine != null)
                StopCoroutine(zoomCoroutine);
    
            //Start new coroutine and zoom within 1 second
            zoomCoroutine = StartCoroutine(lerpFieldOfView(cam, 20, 1f));
        }
    
        if (Input.GetMouseButtonUp(1))
        {
            //Stop old coroutine
            if (zoomCoroutine != null)
                StopCoroutine(zoomCoroutine);
    
            //Start new coroutine and zoom within 1 second
            zoomCoroutine = StartCoroutine(lerpFieldOfView(cam, 60, 1f));
        }
    
    }
    
    
    IEnumerator lerpFieldOfView(Camera targetCamera, float toFOV, float duration)
    {
        float counter = 0;
    
        float fromFOV = targetCamera.fieldOfView;
    
        while (counter < duration)
        {
            counter += Time.deltaTime;
    
            float fOVTime = counter / duration;
            Debug.Log(fOVTime);
    
            //Change FOV
            targetCamera.fieldOfView = Mathf.Lerp(fromFOV, toFOV, fOVTime);
            //Wait for a frame
            yield return null;
        }
    }
