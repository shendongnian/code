    public override void Persist()
    {
        //Get your current row to copy from
        MyDAC rowCopy = PXCache<MyDAC>.CreateCopy(myGraph.MyView.Current)
        //If not saving the updated row you need to remove it from the cache
        MyView.Cache.Remove(MyView.Cache.Current);
        //  If removing more than one just do a foreach on MyView.Cache.Updated
        
        //Change the key fields as needed...
        rowCopy.SomeKey = someNewValue;
        //Change any other fields as needed...
        //Insert into the cache your new row
        rowCopy = myGraph.MyView.Insert(rowCopy);
        base.Persist();
    }
