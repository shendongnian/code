    private Collider thisCollider;
    public event EventHandler<MeEventArgs> OnAction;
    
    void Start()
    {
        thisCollider = GetComponent<Collider>();
    }
    
    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            EventHandler<MeEventArgs> handler = OnAction;
            int actionIndex = DoPlayerLookAtObject();
            if ( handler != null && actionIndex >= 0)
            {
                handler(this, new MeEventArgs(actionIndex));
            }
        }
    }    
    
    int DoPlayerLookAtObject()
    {
        int layerMask = 1 << 9;
        layerMask = ~layerMask;
    
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        bool isHit = Physics.Raycast(_ray, out _hit, 2.0f, layerMask);        
        //if (isHit && _hit.collider == thisCollider)
        //    return true; // this return true all the time after first interaction with object
        //else
        //    return false;
        if (isHit && _hit.collider == thisCollider)
            return ActionList();
        
        return -1;
    }
    
    public int ActionsList()
    {
        int result = -1;
        switch (thisCollider.name)
        {
            case "barthender":   result = 1; break;
            case "doorToStreet": result = 2; break;
            default: Debug.Log("Error: Out of range"); break;
        }
        return result;
    }
