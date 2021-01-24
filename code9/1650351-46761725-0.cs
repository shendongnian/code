    public void loadObject(string objReference, float xPos, float yPos)
    {
        Vector3 tempVec = new Vector3(xPos, yPos, 0);
        Instantiate(Resources.Load<GameObject>(objReference), tempVec, Quaternion.identity);
    
        //I want access to the prefabs properties
    }
