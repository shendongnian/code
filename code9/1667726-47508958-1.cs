    public Camera FPCam; // you have to reassign camera reference through inspector.
    Camera cam; // as usual
     
    void Start()
    {
        anim = GetComponent<Animation>();
        cam = GetComponent<Camera>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        anim.Play("AnimateCameraFirst");
        cam.enabled = true;
        FPCam.enabled = false;
    }
    
    void OnTriggerExit(Collider other)
    {
        FPCam.enabled = true;
        cam.enabled = false;
    }
