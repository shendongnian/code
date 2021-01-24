    static void Main(string[] args)
    {
        List<Base> objects = new List<Base>();
        List<string> serializationIds = new List<string>();
        // SerializationIds initialized somehow
        foreach (var serializationId in serializationIds)
        {
            switch(serializationId)
            {
                // Identify class
                case Derived.SerializationIdText:
                     string serializationId = item.SerializationId;
                     // Do something with serializationId;
                     break;
            }
        }
    }
