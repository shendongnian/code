    public Light[] lightsToDim = null;
    private Coroutine lightCoroutine;
    
    // Use this for initialization
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Flip the scale direction when F key is pressed
            scaleUp = !scaleUp;
    
            //Stop old coroutine
            if (scaleCoroutine != null)
                StopCoroutine(scaleCoroutine);
    
            if (lightCoroutine != null)
                StopCoroutine(lightCoroutine);
    
    
            //Scale  up
            if (scaleUp)
            {
                //Start new coroutine and scale up within 5 seconds and return the coroutine reference
                scaleCoroutine = StartCoroutine(scaleOverTime(objectToScale, maxSize, duration));
                lightCoroutine = StartCoroutine(dimLightOverTime(lightsToDim, 1, duration)); ;
            }
    
            //Scale Down
            else
            {
                //Start new coroutine and scale up within 5 seconds and return the coroutine reference
                scaleCoroutine = StartCoroutine(scaleOverTime(objectToScale, minSize, duration));
                lightCoroutine = StartCoroutine(dimLightOverTime(lightsToDim, 0, duration)); ;
            }
        }
    }
