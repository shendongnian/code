    GameObject objToMove;
    
    void Start()
    {
        objToMove = GameObject.FindGameObjectWithTag("Object");
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (objToMove.transform.position.x > -1.9)
            {
                objToMove.transform.Translate(Vector2.left * szybkosc);
            }
        }
    }
