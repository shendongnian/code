    public static class ResultReaderFactory
    {
        public static IEnumerable<T> ReadResults<T>() where T : Result
        {
            IReader<T> reader = GetReader<T>();
            if(reader != null)
            {
                return reader.ReadResults();   
            }
            return null;
        }
    
        public static IReader<T> GetReader<T>() where T : Result
        {
            // get the first reader implementation from the list
            // that matches the generic definition
            IReader<T> reader = _instances
                                .FirstOrDefault(
                                    r => r.GetType()
                                        .GetInterfaces()
                                        .Any(
                                            i => i == typeof(IReader<T>)
                                        )
                                ) as IReader<T>;
            return reader;
        }
    
        // placeholder for all objects that implement IReader
        static IEnumerable<object> _instances;
    
        static ResultReaderFactory()
        {
            // register all instances of classes,
            // that implements IReader interface
            _instances = typeof(ResultReaderFactory)
                         .Assembly
                         .GetTypes()
                         .Where(
                             t => t.GetInterfaces()
                                 .Any(
                                     i => i.Name
                                         .StartsWith("IReader`1")
                                 )
                         )
                         .Select(t => Activator.CreateInstance(t));  
        }
    }
