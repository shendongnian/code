    private Vector3 originalPos;
    
    void Start()
    {
      //Get the original position
      originalPos = transform.position;
    }
    
    void OnMouseUp()
    {
        _isRotating = false;
        //Reset GameObject to the original position
        transform.position = originalPos;
    }
