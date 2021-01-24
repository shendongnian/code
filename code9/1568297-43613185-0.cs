    public Camera activeCam;
    public float sizeOfText = 20;
    
    void Update () {
    	Vector3 textScreenSpace = activeCam.WorldToScreenPoint(transform.position);
        Vector3 adjustedScreenSpace = new Vector3(textScreenSpace.x, textScreenSpace.y + sizeOfText, textScreenSpace.z);		
    	Vector3 adjustedWorldSpace = activeCam.ScreenToWorldPoint(adjustedScreenSpace); 
        transform.localScale = Vector3.one * (transform.position - adjustedWorldSpace).magnitude;		
    }
