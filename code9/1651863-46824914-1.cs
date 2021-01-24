    List<Attribute> attributeList = new List<Attribute>();
    DbAttribute attrFirst = db.attributes.First();
    for (int i = 0; i < 6; i++)
    {
        attributeList.Add(new Attribute {
            Id = attrFirst.Id,
            Description =(string)attrFirst.GetType().GetProperty("attr" + i).GetValue(attrFirst)
        });
    }
