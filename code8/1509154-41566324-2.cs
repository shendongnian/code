    [SerializeField]
    private float speed = 0.5f;
    private int MAX_TOUCH_COUNT = 5;
    private bool[] touched;
    protected void Start()
    {
        touched = new bool[MAX_TOUCH_COUNT];
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            for(int i = 0; i < (Input.touchCount <= MAX_TOUCH_COUNT ? Input.touchCount : MAX_TOUCH_COUNT); i++)
            {
                if(touched[i] && Input.GetTouch(i).phase == TouchPhase.Ended)
                {
                    touched[i] = false;
                }
                else if (!touched[i] && Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                    RaycastHit hitInfo;
                    if (Physics.Raycast(ray, out hitInfo))
                    {
                        if (hitInfo.transform.GetComponentInChildren<*YOUR_CUBE_CONTROL_CLASS_NAME*>() == this)
                        {
                            touched[i] = true;
                        }
                    }
                }
                else if (touched[i] && Input.GetTouch(i).phase == TouchPhase.Moved)
                {
                    // Get movement of the finger since last frame
                    Vector3 touchDeltaPosition = Input.GetTouch(i).deltaPosition;
                    // Move object across XY plane
                    transform.Translate(touchDeltaPosition.x * speed, 0, 0);
                    Vector3 boundaryVector = transform.position;   
                    boundaryVector.x = Mathf.Clamp (boundaryVector.x, -5.5f, -2.8f);
                    transform.position = boundaryVector;
                }
            }
            else
            {
                touched  = false;
            }
        }
    }
