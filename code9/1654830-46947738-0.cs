    public void RecursiveMethod(object inputCollection)
    {
       // process here
       if(Check for child collection)
       {
           RecursiveMethod(inputCollection.Children)
       }
       // process here no more child exists
    }
