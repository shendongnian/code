    [Test]
    [SecuritySafeCritical] // for Activator.CreateInstance
    public void CriticalClass_PartialTrustAccess()
    {
        var domain = CreateSandboxDomain(
            new ReflectionPermission(ReflectionPermissionFlag.MemberAccess), // Assert.IsFalse
            new EnvironmentPermission(PermissionState.Unrestricted)); // Assert.Throws (if fails)
        var handle = Activator.CreateInstance(domain, Assembly.GetExecutingAssembly().FullName, typeof(Sandbox).FullName);
        var sandbox = (Sandbox)handle.Unwrap();
        try
        {
            sandbox.TestCriticalClass();
            return;
        }
        catch (Exception e)
        {
            // without [InternalTypeReference] it may fail for the first time
            Console.WriteLine($"1st try failed: {e.Message}");
        }
        domain = CreateSandboxDomain(
            new ReflectionPermission(ReflectionPermissionFlag.MemberAccess));
        handle = Activator.CreateInstance(domain, Assembly.GetExecutingAssembly().FullName, typeof(Sandbox).FullName);
        sandbox = (Sandbox)handle.Unwrap();
        sandbox.TestCriticalClass();
        Assert.Inconclusive("Meh... succeeded only for the 2nd try");
    }
    private partial class Sandbox
    {
        public void TestCriticalClass()
        {
            Assert.IsFalse(AppDomain.CurrentDomain.IsFullyTrusted);
            // A type containing critical methods can be created
            var critical = new CriticalClass();
            // Critical method can be called via a safe method
            critical.SafeEntryForCriticalCode();
            // Critical method cannot be called directly by a transparent method
            // !!! May fail for the first time if the test does not use any internal type of the library. !!!
            // !!! Meaning, a partially trusted code has more right than a fully trusted one and is       !!!
            // !!! able to call security critical method directly.                                        !!!
            Assert.Throws<MethodAccessException>(() => critical.CriticalCode());
        }
    }
