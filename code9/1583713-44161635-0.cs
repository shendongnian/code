    public static RequestServiceNumberOfQualifiers ServicesRequest(string person, List<string> users)
    {
        var services = new RequestServiceNumberOfQualifiers();
        var qualifier = new List<RequestServiceNumberOfQualifiersNbrOfQualifiers>();
        qualifier.Add(new RequestServiceNumberOfQualifiersNbrOfQualifiers { Qualifier = 2, Value = person });
        // numberOfQualifiers should be of Type List<List<RequestServiceNumberOfQualifiersNbrOfQualifiers>>
        services.numberOfQualifiers.Add(qualifier.ToArray());
        qualifier = new List<RequestServiceNumberOfQualifiersNbrOfQualifiers>();
        foreach (var userNo in users)
        {
            qualifier.Add(new RequestServiceNumberOfQualifiersNbrOfQualifiers { Qualifier = 3, Value = userNo });
        }                
        services.numberOfQualifiers.Add(qualifier.ToArray());
        return services;
    }
