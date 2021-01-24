    container.Options.AllowOverridingRegistrations = true;
    container.RegisterConditional(
        typeof(IHubConnectionContext<dynamic>),
        Lifestyle.Transient.CreateRegistration(
            () => container.GetInstance<IConnectionManager>().GetHubContext<PlanHub>().Clients,
            container),
        WhenInjectedInto<PlanHubService>);
    container.Options.AllowOverridingRegistrations = false;
