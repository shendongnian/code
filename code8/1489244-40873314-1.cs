    var result=new XElement(ns + "SpecialRegisters");
    if(register.Count()>0)
    {
     result.Add( new XElement(ns + "UpdateRegisters", 
                              register.Select((e,i)=> new XElement(ns + "RegID",i));
    }
