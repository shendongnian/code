    public float MyWait = 5;     // How long to pause over object
    public float speed = 5f;      // How fast to move the camera
    public List<GameObject> Objects;      //List of each object for the camera to go to
    
    
    void Start()
    {
        StartCoroutine(MoveToObject(0));
    }
    
    IEnumerator MoveToObject(int iteratingObject)
    {
        //Wait for however many seconds
        yield return new WaitForSeconds(MyWait);
        bool atDestination = false;
        
        //Move the camera until at destination
        while (!atDestination)
        {
            yield return new WaitForFixedUpdate();
            
            transform.position = Vector3.MoveTowards(transform.position, Objects[iteratingObject].transform.position, Time.deltaTime * speed);
    
            if (transform.position == Objects[iteratingObject].transform.position)
                atDestination = true;
        }
        
        //Continue iterating until moved over all objects in list
        if(iteratingObject != Objects.Count - 1)
            StartCoroutine(MoveToObject(iteratingObject + 1));
    }
