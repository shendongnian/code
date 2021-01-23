    public OperationResult<DataSet> Update(MyThing thing, OperationResult<DataSet> papa)
    {
        // Either you have a result object from enclosing block or you have null.
        var result = OperationResult<DataSet>.Create(papa);
        if (thing.Id == null) return result.Fail("id is null");
        OtherThing original = _repository.GetOtherThing(thing.originalId);
        if (original == null) return result.warn("Item already deleted");
        if (AnyPropertyDiffers(thing, original))
        {
            UpdateThing(thing, original, result));
            // Inside UpdateThing, take result in papa and do this dance once:
            // var result = OperationResult<DataSet>.Create(papa);
        }
        UpdateThingChildren(thing, result);
        // same dance. This adds one line per method of overhead. Eliminates Merge thingy
        _repository.Recalculate(thing, result); 
        return result.ok();
    }
