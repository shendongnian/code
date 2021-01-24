    public GameObject objectToRotate;
    public float speed = 0.36f;
    
    Vector3 pointA;
    Vector3 pointB;
    
    
    void Start()
    {
        //Get current position then add 90 to its Y axis
        pointA = transform.eulerAngles + new Vector3(0f, 90f, 0f);
    
        //Get current position then substract -90 to its Y axis
        pointB = transform.eulerAngles + new Vector3(0f, -90f, 0f);
    
        objectToRotate = this.gameObject;
        StartCoroutine(rotate());
    }
    
    IEnumerator rotate()
    {
        while (true)
        {
            //Rotate 90
            yield return rotateObject(objectToRotate, pointA, 3f);
            //Rotate -90
            yield return rotateObject(objectToRotate, pointB, 3f);
    
            //Wait?
            //yield return new WaitForSeconds(3);
        }
    }
    
    bool rotating = false;
    IEnumerator rotateObject(GameObject gameObjectToMove, Vector3 eulerAngles, float duration)
    {
        if (rotating)
        {
            yield break;
        }
        rotating = true;
    
        Vector3 newRot = gameObjectToMove.transform.eulerAngles + eulerAngles;
    
        Vector3 currentRot = gameObjectToMove.transform.eulerAngles;
    
        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            gameObjectToMove.transform.eulerAngles = Vector3.Lerp(currentRot, newRot, counter / duration);
            yield return null;
        }
        rotating = false;
    }
