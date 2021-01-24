    void SquareClicked()
    {
        foreach(Gameobject square in NeighborList)
        {
            square.transform.parent = transform.parent;
        }
        DoRotate(); //this is where you do the rotation of the parent object.
    }
    
    List<Gameobject> NeighborList = new List<Gameobject>();
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "coloredsquare") //tag each square with this tag.
        {
             NeighborList.Add(col.gameObject);
        }
    }
