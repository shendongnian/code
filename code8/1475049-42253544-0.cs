    private ThingRepository _repository;
    public OperationResult Update(MyThing thing)
    {
        return new OperationResult() //removed Success = true, just make that a default value.
            .Then(() => thing.ValidateId()) //moved id validation into thing
            .Then(() => GetOtherThing(thing.Id)) //GetOtherThing validates original is null or not
            .Then(() => thing.AnyPropertyDiffersFrom(original)) //moved AnyPropertyDiffers into thing
            .Then(() => thing.UpdateChildren())
            .Then(() => _repository.Recalculate(thing));
    }
    private OperationResult GetOtherThing(MyThing ) {...}
