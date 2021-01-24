    private static IDictionary<string, Lazy<IPrint>> prints =
        new Dictionary<string, Lazy<IPrint>> {
            { PrintType.DigitalPrint, new Lazy<IPrint>(() => new DigitalPrint()) },
            { PrintType.InkPrint, new Lazy<IPrint>(() => new InkPrint()) }
        };
