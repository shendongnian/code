    var predicate = PredicateBuilder.False<PropertyPosts>();
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
