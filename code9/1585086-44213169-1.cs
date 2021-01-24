    //Check if oldLength has changed
        if (oldLength != TeleportationBooths.Count)
        {
            //Update oldLength
            oldLength = TeleportationBooths.Count;
    
            //Call your the function
            GeneratePatrolPoints();
        }
    
        GameObject go = GameObject.Find("Button");
        var destroyed = go.GetComponent<GenerateObjectsButton>().destroyed;
        if (destroyed)
        {
            GeneratePatrolPoints();
        }
