    object LockMe = new object();
    public void SomeMethod()
    {
        lock(LockMe)
        {
            <... do something here ...>
        }
    }
