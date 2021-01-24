    var boolLookup = allMyObjects.ToLookup(o => o.BooleanElement);
    var mySelectedObjects = boolLookup[true]
        .OrderBy(o => o.Date)
        .Select((o, index) => new ObjectType
        {
            Element1 = o.Element1,
            Element2 = o.Element2,
            Date = o.Date,
            BooleanElement = index == 0
        })
        .Concat(boolLookup[false])
        .OrderBy(o => o.Date);
