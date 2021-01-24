    void SpawnArrow()
    {
        if (myObjects.Count > 0)
        {
            Destroy(myObjects.Last());
            myObjects.RemoveAt(myObjects.Count - 1);
        }
        // Here hold up the value to use in your if statement
        int randomIndex = UnityEngine.Random.Range(0, arrows.Length);
    
        GameObject prefab = arrows[randomIndex];
        GameObject clone = Instantiate(prefab, new Vector3(0.02F, 2.18F, -1), Quaternion.identity);
    
        myObjects.Add(clone);
    
        // your if statement 
        if ( randomIndex == 1 )
        {
            // your logic
        }
    } 
