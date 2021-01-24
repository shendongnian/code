    public void AddRelationalRecord(object recordToAdd, object recordWithCollection, string collectionFieldName)
    {
        var collectionProp = recordWithCollection.GetType().GetProperty(fieldName);
        collectionProp.PropertyType.GetMethod("Add").Invoke(aaa.GetValue(recordWithCollection, null), new object[] { recordToAdd });           
    }
