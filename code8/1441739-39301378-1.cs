    public static class JsonExtensions
    {
        public static T DeserializeWithTracking<T>(string json, out ICollection<object> objects)
        {
            var tracker = new ReferenceObjectCreationTracker();
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new ObjectCreationTrackerContractResolver(),
                Context = new StreamingContext(StreamingContextStates.All, tracker),
                // Add other settings as required.  
                TypeNameHandling = TypeNameHandling.Auto, 
            };
            var obj = (T)JsonConvert.DeserializeObject<T>(json, settings);
            objects = tracker.CreatedObjects;
            return obj;
        }
    }
