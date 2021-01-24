    public void Update(Foo foo)
    {
        Object idLockObject = _idLocks[foo.Id];
        lock (idLockObject)
        {
            UpdateFirstPart(foo.First);
            UpdateSecondPart(foo.Second);
            UpdateThirdPart(foo.Third);
        }
    }
