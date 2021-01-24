    AllparamsSmooth = facilities.ToDictionary(
        x => x.Name,
        x => (IDictionary<string, IDictionary<DateTime, double>>)names.ToDictionary(
            y => y,
            y => (IDictionary<DateTime, double>)new Dictionary<DateTime, double>()));
