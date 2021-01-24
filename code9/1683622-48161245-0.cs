    List<Vector2> pts = new List<Vector2>();
    
    //The array to assign to the EdgeCollider2D points 
    Vector2 []tempArray = pts.ToArray();
    
    //Check if point is valid
    if(tempArray != null && tempArray.Length >= 2){
        //Enable EdgeCollider2D if previously disabled
        if(!edgeCollider2D.enabled)
        edgeCollider2D.enabled = true;
    
        //Ok to assign the array
        edgeCollider2D.points = tempArray;
    }
    else
    {
        //Point is NOT valid, disable the `EdgeCollider2D` component.
        Debug.Log("Point cannot be null nor less than 2");
        edgeCollider2D.enabled = false;
    }
