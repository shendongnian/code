    var message = new Message();
    //message.TimeToLive = TimeSpan.FromSeconds(10);
    var systemProperties = new Message.SystemPropertiesCollection();
    // systemProperties.EnqueuedTimeUtc = DateTime.UtcNow.AddMinutes(1);
    var bindings = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty;
    var value = DateTime.UtcNow.AddMinutes(1);
    systemProperties.GetType().InvokeMember("EnqueuedTimeUtc", bindings, Type.DefaultBinder, systemProperties, new object[] { value});
    // workaround "ThrowIfNotReceived" by setting "SequenceNumber" value
    systemProperties.GetType().InvokeMember("SequenceNumber", bindings, Type.DefaultBinder, systemProperties, new object[] { 1 });
    // message.systemProperties = systemProperties;
    bindings = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty;
    message.GetType().InvokeMember("SystemProperties", bindings,Type.DefaultBinder, message, new object[] { systemProperties });
