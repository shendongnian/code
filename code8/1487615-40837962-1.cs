    #region Test Class Initialize
    [TestInitialize]
    public void TestInit()
    {
        SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
        _Context = SynchronizationContext.Current;
    }
    #endregion
