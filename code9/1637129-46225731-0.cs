    public override List<CustomObject> TestProperty  
    {  
        get  
        {
            List<CustomObject> objectsFromBase = base.TestProperty;
            List<CustomObject> objectsFromThisClass = GetMySubclassCustomObjects();
            List<CustomObject> retVal = new List<CustomObject>();
            retVal.AddRange(objectsFromBase);
            retVal.AddRange(objectsFromSubclass);
            return retVal;
        }
    }
    private List<CustomObject> GetMySubclassCustomObjects()
    {
        // your code for those two CustomObjects, and returning them from a list
    }
