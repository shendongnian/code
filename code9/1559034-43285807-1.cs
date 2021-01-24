    ctor = type.GetConstructor();
    parameters = ctor.GetParameters();
    foreach (p in parameters)
    {
       // Mark that we have this parameter
    }
    // Construct array of parameters, using garbage values.
    ctor.Invoke(callingParameters);
    // For each parameter we didn't have, read the value.
