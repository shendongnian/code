    void SquareClicked()
    {
        foreach(GameObject square in NeighborList)
        {
            square.transform.parent = gameObject.Transform;
        }
        DoRotate(); //this is where you do the rotation of the parent object.
    }
    
    List<GameObject> NeighborList = new List<GameObject>();
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "coloredsquare") //tag each square with this tag.
        {
             NeighborList.Add(col.gameObject);
        }
    }
