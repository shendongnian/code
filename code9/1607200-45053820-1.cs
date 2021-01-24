    Assembly assembly = typeof(Program).Assembly;
    object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyPulishDateTime), false);
    if (attributes.Length == 1)
    {
        var attribute = attributes[0] as AssemblyPulishDateTime;
        Console.WriteLine(attribute.UtcPublishDateTime);
    }
