    public void loadObject(string objReference, float xPos, float yPos)
    {
        Vector3 tempVec = new Vector3(xPos, yPos, 0);
        GameObject obj = Instantiate(Resources.Load<GameObject>(objReference), tempVec, Quaternion.identity);
    
        //I want access to the prefabs properties
        Debug.Log(obj.transform.position);
        string val = obj.GetComponent<YourScriptName>().yourPropertyName;
        obj.GetComponent<YourScriptName>().yourFunctionName();
    }
