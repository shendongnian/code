    private List<SomeObject> FilterObjects(List<SomeObject> objectList)
    {
        SomeObject finished = objectList.FirstOrDefault(o => o.Status.Equals("Finished"));
        if (finished != null) { return new List<SomeObject> { finished }; }
        List<SomeObject> closed = objectList.SkipWhile(o => !o.Status.Equals("Closed")).ToList();
        if (closed.Count == 1) { return closed; }
        if (closed.Count > 1) { return closed.Skip(1).ToList(); }
        
        // if you need a new list object than return new List<SomeObject>(objectList);
        return objectList;
    }
