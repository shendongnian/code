    public static void MapValues<Tsource, Tdest>(Tsource source, Tdest destination)
        {
            var props = typeof(Tsource).GetProperties();
            foreach (var sourceProp in props)
            {
                var value = sourceProp.GetValue(source);
                var destinationProperty = typeof(Tdest).GetProperty(sourceProp.Name);
                destinationProperty.SetValue(destination, value);
            }
        }
