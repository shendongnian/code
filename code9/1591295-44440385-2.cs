    private static IDictionary<PrintType, IPrint> prints = 
      new Dictionary<PrintType, IPrint> {
          { PrintType.DigitalPrint, new DigitalPrint() },
          { PrintType.InkPrint, new InkPrint() }
      };
