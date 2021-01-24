    var datasets = GetListsOfDatasets().ToArray(); // i.e. the function that returns customerList, productList, vehicleList, etc as a set of List<T>'s
    
    var joins = datasets.First().Select(item => new Dictionary<Type, object> {[item.GetType()] = item});
    var joinTypes = stringList.ToQueue() // the "AND", "OR" that tells how to join next one.  Convert to queue so we can pop of the top.  Better make it enum rather than string.
    
    foreach(dataset in datasets.Skip(1))
    {
        var outerKeyMember = GetPrimaryKeyMember(dataset.GetGenericEnumerableUnderlyingType());
        var innerKeyMember = GetForeignKeyMember(dataset.GetGenericEnumerableUnderlyingType());
        var joinType = joinTypes.Pop();
        if ()
        joins = joinType == "AND:
          ? joins.Join(
            dataset,
            outerKey => ReflectionGetValue(outerKeyMember.Member, outerKey[outerKeyMember.Type]),
            innerKey => ReflectionGetValue(innerKeyMember.Member, innerKey),
            (outer, inner) => {
                outer[inner.GetType] = inner;
                return outer;
            })
          : joins.GroupJoin(/* similar key selection as above */)
                 .SelectMany (i => i) // Flatten the list from IGrouping<T> back to IEnumerable<T>
    }
    
    var finalResult = joins.Select(v => /* TODO: whatever you want to project out, and however you dynamically want to determine what you want out */);
    /////////////////////////////////////
    
    public Type GetGenericEnumerableUnderlyingType<T>(this IEnumerable<T>)
    {
       return typeof(T);
    }
    
    public TypeAndMemberInfo GetPrimaryKeyMember(Type type)
    {
       // TODO
       // Using reflection examine type, look for RelationshipLinkAttribute, and examine PrimaryKey specified on the attribute.
       // Then reflect over BelongsTo declared type and find member declared as PrimaryKey
    
       return new TypeAndMemberInfo {Type = __belongsToType, Member = __relationshipLinkAttribute.PrimaryKey.AsMemberInfo }
    }
    
    public TypeAndMemberInfo GetForeignKeyMember(Type type)
    {
        // TODO Very similar to GetPrimaryKeyMember, but for this type and this type's foreign key annotation marker.
    }
    
    public object ReflectionGetValue(MemberInfo member, object instance)
    {
       // TODO using reflection as member to return value belonging to instance.
    }
