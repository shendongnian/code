    public void Apply(IEnumerable<Event> events) => events.ToList().ForEach(Apply);
    public void Apply(Event ev)
    {
        GetType()
            .GetRuntimeMethods()
            .Where(mi => mi.IsPrivate)
            .Where(mi => mi.Name == "Apply")
            .Where(mi => mi.GetParameters().Length == 1)
            .SingleOrDefault(mi => mi.GetParameters().SingleOrDefault()?.ParameterType == ev.GetType())
            ?.Invoke(this, new[] {ev});
    }
