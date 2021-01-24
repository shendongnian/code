    public static string ToXml(this EventCode.EvCodes value)
    {
      switch(value)
      {
        case EvCodes.DispatchedForDelivery:
        case EvCodes.Delivered:
          return "OD";
        case EvCodes.DepartedFromTerminal:
          return "L1";
      }
    }
