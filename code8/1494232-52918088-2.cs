    /// <summary>
    /// Maps a SqlDataReader record to an object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dataReader"></param>
    /// <param name="newObject"></param>
    public static void MapDataToObject<T>(this SqlDataReader dataReader, T newObject)
    {
        if (newObject == null) throw new ArgumentNullException(nameof(newObject));
        // Fast Member Usage
        var objectMemberAccessor = TypeAccessor.Create(newObject.GetType());
        var propertiesHashSet =
                objectMemberAccessor
                .GetMembers()
                .Select(mp => mp.Name)
                .ToHashSet();
        for (int i = 0; i < dataReader.FieldCount; i++)
        {
            if (propertiesHashSet.Contains(dataReader.GetName(i)))
            {
                objectMemberAccessor[newObject, dataReader.GetName(i)]
                    = dataReader.IsDBNull(i) ? null : dataReader.GetValue(i);
            }
        }
    }
