    private XElement CreateUpdateRegistersOrNullIfEmpty(XNamespace ns,
                                                        IEnumerable<YourType> data)
    {
        return data.Where(reg => reg.IsUpdateRegister)                
                   .Select((reg, i) => new XElement(ns + "RegID", i))
                   .Aggregate(new XElement(ns + "UpdateRegisters"), 
                              (upReg, reg) => 
                              {
                                  upReg.Add(reg);
                                  return upReg;
                              }, 
                              upReg => upReg.HasElements ? upReg : null));
    }
