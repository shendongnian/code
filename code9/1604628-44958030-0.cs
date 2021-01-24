    public void SaveSettings(string SavedFilePath, object Class)
    {
        //open the stream to write the new file
        using (Stream StreamFile = File.Open(SavedFilePath, FileMode.CreateNew))
        {
            //instantiate the binary formatter object
            BinaryFormatter binformat = new BinaryFormatter();
            //loop through all properties in input object
            var query = Class.GetType().GetProperties()
                //Make sure the property is read/write without index parameters
                .Where(p => p.GetIndexParameters().Length == 0 && p.CanRead && p.CanWrite && p.GetGetMethod() != null && p.GetSetMethod() != null)
                //if the property is serializable then serialize it and write its name and value in external file
                .Where(p => p.PropertyType.IsSerializable);
            // Create a dictionary of property names and values.
            // Note that if there are duplicate property names because a derived
            // class hides a property via a "public new" declaration, then
            // an exception will get thrown during serialization.
            var dictionary = query.ToDictionary(p => p.Name, p => p.GetValue(Class, null));
            binformat.Serialize(StreamFile, dictionary);
        }
    }
    public void LoadSettings(string ConfigFile, object Class)
    {
        //open the stream to read the file
        using (Stream StreamFile = File.Open(ConfigFile, FileMode.Open))
        {
            //instantiate the binary formatter object
            BinaryFormatter binformat = new BinaryFormatter();
            var dictionary = (IDictionary<string, object>)binformat.Deserialize(StreamFile);
            //loop through all properties in input object
            foreach (var pair in dictionary)
            {
                var property = Class.GetType().GetProperty(pair.Key);
                if (property != null)
                    property.SetValue(Class, pair.Value, null);
            }
        }
    }
