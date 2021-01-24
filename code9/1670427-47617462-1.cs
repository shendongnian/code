    IEnumerable<BObject> bObjects = aObjects.SelectMany(
        a => a.Types.Select(
            b => new BObject()
            {
                Type = b,
                FirstProp = a.FirstProp,
                SecondProp = a.SecondProp
            }));
