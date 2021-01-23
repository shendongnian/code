    var heartbeatServiceRegistration = (
        from r in container.GetCurrentRegistrations()
        where r.ServiceType.Name == "IHeartbeatService"
        select r)
        .Single();
    var parameterType =
        typeof(HeartbeatController).GetConstructors().Single()
        .GetParameters().First().ParameterType;
    bool areSame = 
        object.ReferenceEquals(parameterType, heartbeatServiceRegistration.ServiceType);
    if (!areSame) throw new Exception("different types");
    container.Verify();
