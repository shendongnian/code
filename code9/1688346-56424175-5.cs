    [Test]
    public void CriticalClass_FullTrustAccess()
    {
        Assert.IsTrue(AppDomain.CurrentDomain.IsFullyTrusted);
        // A type containing critical methods can be created
        var critical = new CriticalClass();
        // Critical method cannot be called directly by a transparent method
        Assert.Throws<MethodAccessException>(() => critical.CriticalCode());
        // Critical method can be called via a safe method
        critical.SafeEntryForCriticalCode();
    }
    [Test]
    public void SerializableCriticalClass_FullTrustAccess()
    {
        Assert.IsTrue(AppDomain.CurrentDomain.IsFullyTrusted);
        // ISerializable implementer can be created
        var critical = new SerializableCriticalClass();
        // Critical method cannot be called directly by a transparent method (see also AllowPartiallyTrustedCallersAttribute)
        Assert.Throws<MethodAccessException>(() => critical.CriticalCode());
        Assert.Throws<MethodAccessException>(() => critical.GetObjectData(null, default(StreamingContext)));
        // Critical method can be called via a safe method
        critical.SafeEntryForCriticalCode();
        // BinaryFormatter calls the critical method via a safe route
        new BinaryFormatter().Serialize(new MemoryStream(), critical);
    }
