    var predicate = PredicateBuilder.False<PropertyPosts>();
    //predicate = predicate.OR(x=>x.SomeProperties == someValues);
    //predicate = predicate.AND(x=>x.SomeOtherProperties == someOtherValues);
   
    if (item.ApartmentCondo == 1)
    {
        predicate = predicate.OR(x => x.name == item.name &&
                            x.PropertyType == PropertyType.ApartmentCondo );
    }
    if (item.House == 1)
    {
       predicate = predicate.OR(x => x.name == item.name &&
                            x.PropertyType == PropertyType.House );
    }
    List<PropertyPosts> posts2 = posts.Where(predicate).ToList();
