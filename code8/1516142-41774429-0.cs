      public static List<T> DeserializeJObjectsToObjects<T>(IEnumerable<JObject> jObjects, string typeKey, string nameSpaceOfClass)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            List<T> convert = new List<T>();
            foreach (var jObject in jObjects)
            {
                JToken typeName;
                jObject.TryGetValue(typeKey, out typeName);
                string fullNameSpace = string.Format(nameSpaceFormat, nameSpaceOfClass, typeName);
                Type t = Type.GetType(string.Format(fullNameSpace));
                convert.Add((T) Activator.CreateInstance(t));
            }
            return convert;
        }
        public static List<JObject> SerializeObjectsToJObjects<T>(IEnumerable<T> variableObjects )
        {
            List<JObject> convert = new List<JObject>();
            foreach (T variableObject in variableObjects)
            {
                var jsonString = JsonConvert.SerializeObject(variableObject);
                convert.Add(JObject.Parse(jsonString));
            }
            return convert;
        }
