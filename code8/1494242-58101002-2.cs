        /// <summary>
        /// Maps a SqlDataReader record to an object. Ignoring case.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataReader"></param>
        /// <param name="newObject"></param>
        /// <remarks>https://stackoverflow.com/a/52918088</remarks>
        public static void MapDataToObject<T>(this SqlDataReader dataReader, T newObject)
        {
            if (newObject == null) throw new ArgumentNullException(nameof(newObject));
            // Fast Member Usage
            var objectMemberAccessor = TypeAccessor.Create(newObject.GetType());
            var propertiesHashSet =
                    objectMemberAccessor
                    .GetMembers()
                    .Select(mp => mp.Name)
                    .ToHashSet(StringComparer.InvariantCultureIgnoreCase);
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                var name = propertiesHashSet.FirstOrDefault(a => a.Equals(dataReader.GetName(i), StringComparison.InvariantCultureIgnoreCase));
                if (!String.IsNullOrEmpty(name))
                {
                    objectMemberAccessor[newObject, name]
                        = dataReader.IsDBNull(i) ? null : dataReader.GetValue(i);
                }
            }
        }
