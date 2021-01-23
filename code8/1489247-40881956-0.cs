    var specialRegisters = 
    new XElement(ns + "SpecialRegisters", 
                 Registers.Registers.Singleton.Where(reg => reg.IsUpdateRegister)
                                              .Select((reg, i) => new XElement(ns + "RegID", i))
                                              .Aggregate(new XElement(ns + "UpdateRegisters"), 
                                                         (upReg, reg) => 
                                                         {
                                                             upReg.Add(reg);
                                                             return upReg;
                                                         }, 
                                                         upReg => upReg.HasElements ? upReg : null));
