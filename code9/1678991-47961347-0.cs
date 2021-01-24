    public GameObject objectToScale;
    public Vector3 minSize;
    public Vector3 maxSize;
    
    private bool scaleUp = false;
    private Coroutine scaleCoroutine;
    
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
    
            //Scale  up
            if (scaleUp)
            {
                //Start new coroutine and scale up within 5 seconds and return the coroutine reference
                scaleCoroutine = StartCoroutine(scaleOverTime(objectToScale, maxSize, 5f));
            }
    
            //Scale Down
            else
            {
                //Start new coroutine and scale up within 5 seconds and return the coroutine reference
                scaleCoroutine = StartCoroutine(scaleOverTime(objectToScale, minSize, 5f));
            }
        }
    }
    
    IEnumerator scaleOverTime(GameObject targetObj, Vector3 toScale, float duration)
    {
        float counter = 0;
    
        //Get the current scale of the object to be scaled
        Vector3 startScaleSize = targetObj.transform.localScale;
    
        while (counter < duration)
        {
            counter += Time.deltaTime;
            targetObj.transform.localScale = Vector3.Lerp(startScaleSize, toScale, counter / duration);
            yield return null;
        }
    }
