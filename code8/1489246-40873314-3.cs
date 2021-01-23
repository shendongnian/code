    var result=new XElement(ns + "SpecialRegisters");
    var updateRegister=register.Where(e=>e.IsUpdateRegister);// To not repeat the same query twice
    if(updateRegister.Count()>0)
    {
     result.Add( new XElement(ns + "UpdateRegisters", 
                              updateRegister.Select((e,i)=> new XElement(ns + "RegID",i));
    }
