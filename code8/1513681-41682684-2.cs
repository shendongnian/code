    public ServiceAppointment UpdateService(Guid serviceGuid, Guid serviceActivityGuid, Action<Entity> action)
    {
        var serviceAppointment = organizationService.Retrieve(
                "serviceappointment",
                serviceActivityGuid,
                new ColumnSet(true));
        action(serviceAppointment);
        organizationService.Update(serviceAppointment);
        return GetServiceActivity(serviceActivityGuid);
    }
