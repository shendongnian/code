    private Quaternion originalPos;
    
    void Start()
    {
      //Get the original rotation
      originalPos = transform.rotation;
    }
    
    void OnMouseUp()
    {
        _isRotating = false;
        //Reset GameObject to the original rotation
        transform.rotation = originalPos;
    }
