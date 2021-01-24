    public float rotationSpeed = 0.01f ;
    private Transform child;
    private float initialYRotation;
    private bool textChanged = false;
    private void Awake()
    {
        child = transform.GetChild(0);
        initialYRotation = child.rotation.eulerAngles.y ;
    }
    private void Update()
    {
        Quaternion fromRotation = child.rotation ;
        Quaternion toRotation = Quaternion.Euler( 0, 180, 0 ) ; // Not the same as new Quaternion(0, 180, 0, 0) !!!
        Quaternion rotation = Quaternion.Lerp( fromRotation, toRotation, Time.deltaTime * rotationSpeed );
        child.rotation = rotation;
        if( !textChanged && Mathf.Abs( child.rotation.eulerAngles.y - initialYRotation ) > 90 )
        {
            // Change the text
            textChanged = true ;
        }
    }
