    public void Update(Foo foo)
    {
        Object IdLockObject = _idLocks[foo.Id];
        lock (IdLockObject)
        {
            UpdateFirstPart(foo.First);
            UpdateSecondPart(foo.Second);
            UpdateThirdPart(foo.Third);
        }
    }
