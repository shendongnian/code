    [Test]
    [SecuritySafeCritical] // for Activator.CreateInstance
    public void SerializableCriticalClass_PartialTrustAccess()
    {
        var domain = CreateSandboxDomain(
            new SecurityPermission(SecurityPermissionFlag.SerializationFormatter), // BinaryFormatter
            new ReflectionPermission(ReflectionPermissionFlag.MemberAccess)); // Assert.IsFalse
        var handle = Activator.CreateInstance(domain, Assembly.GetExecutingAssembly().FullName, typeof(Sandbox).FullName);
        var sandbox = (Sandbox)handle.Unwrap();
        try
        {
            sandbox.TestSerializableCriticalClass();
            return;
        }
        catch (Exception e)
        {
            // without [InternalTypeReference] it may fail for the first time
            Console.WriteLine($"1st try failed: {e.Message}");
        }
        domain = CreateSandboxDomain(
            new SecurityPermission(SecurityPermissionFlag.SerializationFormatter), // BinaryFormatter
            new ReflectionPermission(ReflectionPermissionFlag.MemberAccess)); // Assert.IsFalse
        handle = Activator.CreateInstance(domain, Assembly.GetExecutingAssembly().FullName, typeof(Sandbox).FullName);
        sandbox = (Sandbox)handle.Unwrap();
        sandbox.TestSerializableCriticalClass();
        Assert.Inconclusive("Meh... succeeded only for the 2nd try");
    }
    private partial class Sandbox
    {
        public void TestSerializableCriticalClass()
        {
            Assert.IsFalse(AppDomain.CurrentDomain.IsFullyTrusted);
            // ISerializable implementer can be created.
            // !!! May fail for the first try if the test does not use any internal type of the library. !!!
            var critical = new SerializableCriticalClass();
            // Critical method can be called via a safe method
            critical.SafeEntryForCriticalCode();
            // Critical method cannot be called directly by a transparent method
            Assert.Throws<MethodAccessException>(() => critical.CriticalCode());
            Assert.Throws<MethodAccessException>(() => critical.GetObjectData(null, new StreamingContext()));
            // BinaryFormatter calls the critical method via a safe route (SerializationFormatter permission is required, though)
            new BinaryFormatter().Serialize(new MemoryStream(), critical);
        }
    }
