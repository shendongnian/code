    var allowEveryoneRule =
        new MutexAccessRule(
            new SecurityIdentifier(WellKnownSidType.WorldSid, null),
            MutexRights.FullControl, AccessControlType.Allow);
    var securitySettings = new MutexSecurity();
    securitySettings.AddAccessRule(allowEveryoneRule);
    string mutexId = @"Global\MyProg";
    bool createdNew;
    using (var mutex = new Mutex(false, mutexId, out createdNew, securitySettings))
    {
    }
