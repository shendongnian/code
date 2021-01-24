    int controllableLayer ;
    void Awake()
    {
        controllableLayer = 1 << LayerMask.NameToLayer("Controllable");
    }
    void Update()
    {
        // ...
        if( Physics.Raycast(firstPersonCamera.ScreenPointToRay(Input.GetTouch(0).position), out hit, controllableLayer) )
        {
            // ...
        }
    }
