    public List<ClassA> GetLists(Dictionary<string, Dictionary<IEnumerable, Dictionary<string, ClassB>>> groups)
    {
        return groups
            .SelectMany(grp1 => grp1.Value
                .SelectMany(grp2 => grp2.Value
                    .SelectMany(grp3 => grp3.Value.ItemId
                        .IntoChunks(2000)
                        .Select(itemIdList =>
                            new ClassA
                            {
                                TransactionType = grp1.Key,
                                Filters = grp2.Key is Dictionary<string, object> ? 
                                    (Dictionary<string, object>)grp2.Key :
                                    new Dictionary<string, object>(),
                                ItemIds = new List<string>(itemIdList),
                                PropStreamsDict = new Dictionary<string, Tuple<long, string>>
                                {
                                    { grp3.Key, Tuple.Create(grp3.Value.StreamId, grp3.Value.Uom) }
                                }
                            }
                        )
                    )
                )
            )
            .ToList();
    }
