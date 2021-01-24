    GameObject oldLine = gameObject;
    GameObject newLine = Instantiate(oldLine);
    
    LineRenderer oldLineComponent = oldLine.GetComponent<LineRenderer>();
    
    //Get old Position Length
    Vector3[] newPos = new Vector3[oldLineComponent.positionCount];
    //Get old Positions
    oldLineComponent.GetPositions(newPos);
    
    //Copy Old postion to the new LineRenderer
    newLine.GetComponent<LineRenderer>().SetPositions(newPos);
