    public void afterPlayerMove(object cmpParams)
    {
        Hashtable hstbl = (Hashtable)cmpParams;
        Debug.Log("Your value " + (int)hstbl["value"]);
    }
