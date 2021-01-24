    List<GameObject> TeleportationBooths = new List<GameObject>();
    int oldLength;
    
    void Start()
    {
        GameObject[] tempObj = GameObject.FindGameObjectsWithTag("Teleportation Booth");
        for (int i = 0; i < tempObj.Length; i++)
        {
            //Add to list only if it does not exist
            if (!TeleportationBooths.Contains(tempObj[i]))
            {
                TeleportationBooths.Add(tempObj[i]);
            }
        }
    
        //Get the current Size
        if (tempObj != null)
        {
            oldLength = tempObj.Length;
        }
    }
    
    void Update()
    {
        //Check if oldLength has changed
        if (oldLength != TeleportationBooths.Count)
        {
            //Update oldLength
            oldLength = TeleportationBooths.Count;
    
            //Call your the function
            GeneratePatrolPoints();
        }
    }
