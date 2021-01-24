    public static IEnumerable<T> Initialize<T where T : BaseClass>()
    {
        var allCalls = new List<T>();
        allCalls.Add(new PhoneCall { /* Details */};
        return allCalls;
    }
