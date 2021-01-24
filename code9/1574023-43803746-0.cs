    EntityClass entityClass = new EntityClass();
    entityClass.propname1 = "abc";
    entityClass.propname2 = "def";
    
    System.ComponentModel.PropertyDescriptorCollection pdc = System.ComponentModel.TypeDescriptor.GetProperties(entityClass);
    var dict = pdc.OfType<PropertyDescriptor>().GroupBy(x => x.Category).ToDictionary(x => x.Key, x => x.Select(p => p.GetValue(entityClass).ToString()).ToList());
