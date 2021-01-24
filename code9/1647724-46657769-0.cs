    //The global variable that holds the arrayVariableName to access
    static string targetBox = null;
    
    //Implicit conversion operators (box array name to this script(MyScript) instance)
    public static implicit operator MyScript(string box)
    {
        return setTargetAndGetInstance(box);
    }
    
    public static MyScript setTargetAndGetInstance(string box)
    {
        if (instance.boxes.ContainsKey(box))
        {
            //Set the box requested. This will be needed in the Indexer overloading above
            targetBox = box;
            return instance;
        }
        else
            return null;
    }
